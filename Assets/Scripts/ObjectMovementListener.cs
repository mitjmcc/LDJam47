using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovementListener : MonoBehaviour
{
    public float moveSpeed = 15.0f;

    private Vector2 m_Move;

    void Awake()
    {
        ObjectMovementEvents.OnMoveAction += Listener_OnMove;
    }

    void Listener_OnMove (Vector2 direction)
    {
        m_Move = direction;
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
