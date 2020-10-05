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

            if (position.x > 4.0f) {
                position.x = 4.0f;
            } else if (position.x < -6.0f) {
                position.x = -6.0f;
            }

            roadList[i].position = position;

            position.x += 8.42f;
            roadOffRampList[i].position = position;
        }

        position = roadList[0].position;
        position.z = 0f;
        position.x += 62.1f;
        roadCurve.position = position;

        var rotation = roadCurve.eulerAngles;
        rotation.y -= 1f;
        roadCurve.eulerAngles = rotation;
    }

    void RoadSpawner_OnMove (Vector2 direction)
    {
        m_Move = direction;
    }
}
