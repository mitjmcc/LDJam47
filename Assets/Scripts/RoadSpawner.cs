using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public Transform roadCurve;

    [SerializeField]
    private float moveSpeed = 1.0f;
    [SerializeField]
    private List<Transform> roadList;
    [SerializeField]
    private List<Transform> roadOffRampList;
    private Vector2 m_Move;

    private float layerSpawnTracker;
    private float roadSize = 10f;
    private float laneChangeSpeed = 0.25f;

    private static float roadOffset;

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

        var position = Vector3.zero;
        for(int i = 0; i < roadList.Count; i++)
        {
            position = roadList[i].position;

            position.z -= moveSpeed;

            if (position.z < -2 * roadSize)
            {
                position.z += 6 * roadSize;
            }

            position.x -= direction.x * laneChangeSpeed;

            if (position.x > 2.0f) {
                position.x = 2.0f;
            } else if (position.x < -2.0f) {
                position.x = -2.0f;
            }

            roadList[i].position = position;
        }
        roadOffset = roadList[0].position.x;
    }

    void RoadSpawner_OnMove (Vector2 direction)
    {
        m_Move = direction;
    }

    public static float GetRoadOffset()
    {
        return roadOffset;
    }
}
