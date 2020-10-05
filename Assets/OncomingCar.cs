using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OncomingCar : MonoBehaviour
{
    private Vector2 m_Move;

    void Awake()
    {
        ObjectMovementEvents.OnMoveAction += OncomingCar_OnMove;
    }

    void FixedUpdate()
    {
        var postition = transform.position;
        postition.z -= 25f * Time.fixedDeltaTime;
        transform.position = postition;
    }

    void OncomingCar_OnMove (Vector2 direction)
    {
        m_Move = direction;
    }
}
