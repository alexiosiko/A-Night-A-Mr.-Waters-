using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OwnerInteractable : Interactable
{
    string nameOfWeapon = "knife";
    public override void Action()
    {
        if (die == true)
            PickupHouseKey();
        else
            UseItemOnOwner();
    }
    void UseItemOnOwner()
    {
        GameObject item = PlayerInventory.instance.GetCurrentItem();
        if (item == null)
            return;

        Collectable collectable = item.GetComponent<Collectable>();
        if (collectable.itemId == nameOfWeapon)
        {
            // Destory item
            PlayerInventory.instance.DestoryCurrentItem();

            // Kill owner
            Die();
        }
    }
    public GameObject houseKey;
    void PickupHouseKey()
    {
        // Change layer
        houseKey.layer = LayerMask.NameToLayer("Viewmodel");

        // Set parent
        houseKey.transform.SetParent(inventoryTransform);

        // Move to position
        houseKey.transform.localPosition = PlayerInventory.instance.positionToTheSide;

        // Call this function so we can update what object is currently or is NOT 
        // currently in player's hand
        PlayerInventory.instance.ShowNextItem();

        // Canvas
        CanvasManager.instance.Alert("You pick up the house key! You may now leave in peace with Oliver <3");

        // Destroy this script
        Destroy(this);
    }
    bool die = false;
    void Die()
    {
        OwnerBehaviour ownerBehaviour = GetComponent<OwnerBehaviour>();
        ownerBehaviour.CancelInvoke();
        ownerBehaviour.enabled = false;
        
        GetComponent<NavMeshAgent>().enabled = false;

        GetComponent<Animator>().CrossFade("die", 0.1f);

        Invoke("DieBool", 3f);
    }
    void DieBool()
    {
        die = true;
        cursorIndex = 1;
    }
    void Awake()
    {
        inventoryTransform = GameObject.FindWithTag("Inventory").transform;
    }
    Transform inventoryTransform;
}
