using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnerCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Door door = other.gameObject.GetComponent<Door>();
        if (door != null)
        {
            // If door is already opened then STOP
            if (door.opened == true)
                return;

            door.OpenDoor();
            owner.Freeze(0.75f);    
        }
    }
    void Start()
    {
        owner = GetComponentInParent<OwnerBehaviour>();
    }
    OwnerBehaviour owner;
}
