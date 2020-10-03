using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class ObjectMover : MonoBehaviour
{
    public float moveSpeed;

    private Vector2 m_Move;

    public static event Action<string> OnMoveAction;

    public void OnMove(InputAction.CallbackContext context)
    {
        m_Move = context.ReadValue<Vector2>();
        Debug.Log("Time to fire OnMove event");

        OnMoveAction("This string will be received by listener as arg");
    }

    public void Update()
    {
        Move(m_Move);
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01)
            return;
        var move = new Vector3(direction.x, 0, direction.y);
        var scaledMoveSpeed = moveSpeed * Time.deltaTime;
        transform.position += move * scaledMoveSpeed;
    }
}
