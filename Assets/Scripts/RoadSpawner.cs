using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject roadPiece;
    public GameObject roadParent;

    [SerializeField]
    private float moveSpeed = 1.0f;
    private List<Transform> roadList;
    private Vector2 m_Move;

    private float layerSpawnTracker;

    void Awake()
    {
        roadList = new List<Transform>();
        for (int i = -10; i < 300; ++i)
        {
            var roadLayer = Instantiate(roadPiece) as GameObject;
            roadLayer.transform.parent = roadParent.transform;
            roadLayer.transform.position = new Vector3(0, 0, i);
            roadLayer.GetComponent<ObjectMovementListener>().id = i;
            if (i == -10)
            {
                roadLayer.AddComponent<RadioEvent>();
            }
            roadList.Add(roadParent.transform);
        }

        ObjectMovementListener.OnPassedByAction += RoadSpawner_OnPassedBy;
        ObjectMovementEvents.OnMoveAction += RoadSpawner_OnMove;
    }

    void FixedUpdate()
    {
        Move(m_Move);
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01)
            return;
        int i = 0;
        foreach(Transform roadPiece in roadList)
        {
            var move = new Vector3(0, 0, -direction.y);
            var scaledMoveSpeed = moveSpeed * Time.fixedDeltaTime;
            // var distanceToCar = Vector3.Distance(roadPiece.position, new Vector3(0, 0, -10));
            roadPiece.position += move * scaledMoveSpeed;
            // var roadCurveOffset = /* Vector3.Lerp( */new Vector3(0.5f * i, 0, roadPiece.position.z)/* , Vector3.zero, distanceToCar) */;
            // roadPiece.position = roadCurveOffset;
            i++;
        }
        layerSpawnTracker += direction.y * moveSpeed * Time.fixedDeltaTime;
        if (layerSpawnTracker > 1.0f)
        {
            NewRoadLayer();
            layerSpawnTracker = 0f;
        }
        print(layerSpawnTracker);
    }

    void RoadSpawner_OnMove (Vector2 direction)
    {
        m_Move = direction;
    }

    void RoadSpawner_OnPassedBy(ObjectMovementListener objectMovement)
    {
        // objectMovement.transform.position = new Vector3(0, 0, 300f);


    }

    void NewRoadLayer()
    {
        var roadLayer = Instantiate(roadPiece);
        roadLayer.transform.parent = roadParent.transform;
        roadLayer.transform.position = roadList.ToArray()[roadList.Count-1].transform.position + Vector3.forward;
        roadLayer.GetComponent<ObjectMovementListener>().id = roadList.Count;
        roadList.Add(roadParent.transform);
    }
}
