using UnityEngine;

public class RadioEvent : MonoBehaviour
{

    void Awake()
    {
        ObjectMovementListener.OnPassedByAction += RadioEvent_OnPassedBy;
    }

    void RadioEvent_OnPassedBy(ObjectMovementListener objectMovement)
    {
        if (objectMovement.id == this.GetComponent<ObjectMovementListener>().id)
        {
            print("THis is radio 88.8 the loop");
        }
    }
}
