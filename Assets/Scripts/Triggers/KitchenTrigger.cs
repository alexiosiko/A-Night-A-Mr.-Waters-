using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenTrigger : Trigger
{
    [SerializeField] OwnerBehaviour ownerBehaviour;
    [SerializeField] Door door1;
    [SerializeField] Door door2;
    [SerializeField] Vector3 ownerDestination;
    protected override void Action()
    {
        CanvasManager.instance.Alert("Oh no ... I think the owner woke up ... Hide under the dining table and wait for him to leave", 5f);
        ownerBehaviour.enabled = true;
        ownerBehaviour.SetDestination(ownerDestination);
        door1.Unlock();
        door2.Unlock();
        base.Action();
    }
}
