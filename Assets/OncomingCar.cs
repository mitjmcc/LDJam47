using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OncomingCar : MonoBehaviour
{
    [SerializeField]
    private float carSpeed;
    [SerializeField]
    private float carOffset;

    void FixedUpdate()
    {
        var position = transform.position;
        position.z -= carSpeed * Time.fixedDeltaTime;
        position.x = RoadSpawner.GetRoadOffset() - carOffset;
        if (position.z < -20)
        {
            position.z += 64;
        }
        transform.position = position;
    }
}
