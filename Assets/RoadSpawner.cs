using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject roadPiece;

    void Awake()
    {
        var road = new GameObject("Road");
        for (int i = 0; i < 300; ++i)
        {
            var roadLayer = Instantiate(roadPiece);
            roadLayer.transform.parent = road.transform;
            roadLayer.transform.position = new Vector3(0, 0, i);
        }
    }
}
