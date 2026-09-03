using System;
using UnityEngine;

public class BaseInputController : MonoBehaviour
{  
    private event Action<Vector2> MoveInput;

    protected void InvokeMoveInput(Vector2 moveInput)
    {
        MoveInput?.Invoke(moveInput);
    }

    public void SubscribeMoveInput(Action<Vector2> subscriber)
    {
        if (subscriber == null)
            return;
        MoveInput += subscriber;
    }

    public void UnsubscribeMoveInput(Action<Vector2> subscriber)
    {
        if (subscriber == null)
            return;
        MoveInput -= subscriber;
    }
}
