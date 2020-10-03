using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class ObjectMovementEvents : MonoBehaviour
{
    public static event Action<Vector2> OnMoveAction;

    public void OnMove(InputAction.CallbackContext context)
    {
        var m_Move = context.ReadValue<Vector2>();

        OnMoveAction(m_Move);
    }
}
