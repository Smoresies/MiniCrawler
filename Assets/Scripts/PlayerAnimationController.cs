using System;
using UnityEngine;

[RequireComponent(typeof(BaseInputController))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimationController : MonoBehaviour
{
   private Animator _animator;
   private SpriteRenderer _spriteRenderer;
   private Vector2 _lastMoveInput = Vector2.zero;
   
   private void Start()
   {
      _animator = GetComponent<Animator>();
      _spriteRenderer = GetComponent<SpriteRenderer>();
   }

   private void OnEnable()
   {
      GetComponent<BaseInputController>().SubscribeMoveInput(MoveAnimationUpdate);
   }

   private void OnDisable()
   {
      GetComponent<BaseInputController>().UnsubscribeMoveInput(MoveAnimationUpdate);
   }
   
   private void MoveAnimationUpdate(Vector2 moveInput)
   {
      _animator.SetFloat("AnimMoveX", moveInput.x);
      _animator.SetFloat("AnimMoveY", moveInput.y);
      
      _animator.SetFloat("AnimMoveMagnitude", moveInput.sqrMagnitude);
      
      _animator.SetFloat("LastAnimMoveX", _lastMoveInput.x);
      _animator.SetFloat("LastAnimMoveY", _lastMoveInput.y);
      
      if(moveInput.magnitude > 0)
         _lastMoveInput = moveInput;
      

      if (moveInput.x < 0)
         _spriteRenderer.flipX = true;
      else if (moveInput.x > 0)
         _spriteRenderer.flipX = false;
   }
}
