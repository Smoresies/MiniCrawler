using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : BaseInputController
{
    void OnMove(InputValue val)
    {
        // SHOULD be clamped, but this can happen subscriber-side so each can handle to their own needs.
        InvokeMoveInput(val.Get<Vector2>());
    }
}
