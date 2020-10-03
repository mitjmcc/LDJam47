using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectMover : MonoBehaviour
{
    public float moveSpeed;

    private Vector2 m_Move;

    public void OnMove(InputAction.CallbackContext context)
    {
        m_Move = context.ReadValue<Vector2>();
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
