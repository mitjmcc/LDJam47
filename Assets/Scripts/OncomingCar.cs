using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OncomingCar : MonoBehaviour
{
    [SerializeField]
    private float carSpeed;
    [SerializeField]
    private float carOffset;
    [SerializeField]
    private GameObject crashParticles;

    private Vector3 player_pos;
    private MeshRenderer mesh;

    void Awake()
    {
        player_pos = new Vector3(0, 1, -10f);
        mesh = GetComponent<MeshRenderer>();
    }

    void FixedUpdate()
    {
        var position = transform.position;
        position.z -= carSpeed * Time.fixedDeltaTime;
        position.x = RoadSpawner.GetRoadOffset() - carOffset;
        if (position.z < -20)
        {
            position.z += 64;
            mesh.enabled = true;
        }
        transform.position = position;

        if (Vector3.Distance(position, player_pos) < 2.5f)
        {
            mesh.enabled = false;
            Instantiate(crashParticles, this.transform);
        }
    }
}
