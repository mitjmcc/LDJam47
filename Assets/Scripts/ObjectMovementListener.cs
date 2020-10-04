using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectMovementListener : MonoBehaviour
{
    public int id;
    public static event Action<ObjectMovementListener> OnPassedByAction;

    public void FixedUpdate()
    {
        CheckPassedBy();
    }

    private void CheckPassedBy()
    {
        if (transform.position.z < -10)
        {
            OnPassedByAction(this);
        }
    }
}
