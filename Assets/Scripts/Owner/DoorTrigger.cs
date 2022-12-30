using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Door door = other.gameObject.GetComponent<Door>();
        if (door != null)
        {
            door.Action();
            owner.Freeze(0.75f);
        }
    }
    void Start()
    {
        owner = GetComponentInParent<OwnerMovement>();
    }
    OwnerMovement owner;
}
