using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BaseInputController))]
public class MovementController : MonoBehaviour
{
    private Vector2 _moveInput =  Vector2.zero;
    private Rigidbody2D _rb;
    
    [SerializeField]
    private float _speed = 5.0f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        GetComponent<BaseInputController>().SubscribeMoveInput(MoveUpdate);
    }

    private void OnDisable()
    {
        GetComponent<BaseInputController>().UnsubscribeMoveInput(MoveUpdate);
    }

    /// <summary>
    /// The entry point for movement.
    /// 
    /// This EXPECTS a Vector2 that is clamped to a magnitude of 1.0f maximum.
    ///
    /// If not, it will enforce such.
    /// </summary>
    /// <param name="moveInput"></param>
    private void MoveUpdate(Vector2 moveInput)
    {
        // Clamp if not done already
        // Should be handled by Unity New Input Manager already?
        _moveInput = moveInput.magnitude < 1.0f ? moveInput : Vector2.ClampMagnitude(moveInput, 1.0f);
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _moveInput * _speed;
    }
}
