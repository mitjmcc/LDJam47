using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI digitalClock;
    [SerializeField]
    private float currentTime;
    [SerializeField]
    private Transform sun;

    void Start()
    {
        currentTime = 300;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        int hours = Mathf.FloorToInt(currentTime / 60 % 12 + 1);
        int minutes = Mathf.FloorToInt(currentTime % 60);

        digitalClock.text = string.Format("{0:00}:{1:00}", hours, minutes);

        var sun_angles = sun.eulerAngles;
        sun_angles.z = -minutes / 2;
        sun.eulerAngles = sun_angles;
    }
}
