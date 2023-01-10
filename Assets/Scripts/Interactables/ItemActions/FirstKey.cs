using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstKey : Interactable
{
    public Vector3 ownerDestination;
    public Door door;
    public override void Action()
    {
        OwnerBehaviour.instance.SetDestination(ownerDestination);

        door.Unlock();
    }
}
