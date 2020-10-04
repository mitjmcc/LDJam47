using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public Transform roadCurve;

    [SerializeField]
    private float moveSpeed = 1.0f;
    [SerializeField]
    private List<Transform> roadList;
    private Vector2 m_Move;

    private float layerSpawnTracker;
    private float roadSize = 10f;

    void Awake()
    {
        ObjectMovementEvents.OnMoveAction += RoadSpawner_OnMove;
    }

    void FixedUpdate()
    {
        Move(m_Move);
    }

    private void Move(Vector2 direction)
    {
        // if (direction.sqrMagnitude < 0.01)
        //     return;

        for(int i = 0; i < roadList.Count; i++)
        {
            var position = roadList[i].position;

            position.z -= moveSpeed;

            if (position.z < -2 * roadSize)
            {
                position.z += 6 * roadSize;
            }

            roadList[i].position = position;
        }

        var rotation = roadCurve.eulerAngles;
        rotation.y -= 1f;
        roadCurve.eulerAngles = rotation;

    }

    void RoadSpawner_OnMove (Vector2 direction)
    {
        m_Move = direction;
    }
}
