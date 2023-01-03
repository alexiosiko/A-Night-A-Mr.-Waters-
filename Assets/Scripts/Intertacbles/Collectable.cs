using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactable
{
    public string itemId = "";
    public override void Action()
    {
        // Change layer
        gameObject.layer = LayerMask.NameToLayer("Viewmodel");

        // Set parent
        transform.SetParent(inventoryTransform);

        // Move to position
        transform.localPosition = PlayerInventory.instance.positionToTheSide;
    }
    void Awake()
    {
        inventoryTransform = GameObject.FindWithTag("Inventory").transform;
    }
    void Start()
    {
        cursorIndex = 1;
    }
    Transform inventoryTransform;
}
