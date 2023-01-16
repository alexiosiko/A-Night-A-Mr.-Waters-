using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Collectable
{
    [SerializeField] GameObject knife;
    public override void Action()
    {
        // Change layer and for each child cause chicken and material
        gameObject.layer = LayerMask.NameToLayer("Viewmodel");
        foreach (Transform child in transform)
        {
            child.gameObject.layer = LayerMask.NameToLayer("Viewmodel");
        }


        // Set parent
        transform.SetParent(inventoryTransform);

        // Move to position
        transform.localPosition = PlayerInventory.instance.positionToTheSide;

        // Call this function so we can update what object is currently or is NOT 
        // currently in player's hand
        PlayerInventory.instance.ShowNextItem();

        // Canvas
        CanvasManager.instance.Alert("I found Oliver! Now I have to find a weapon to kill the owner and search him for a key ...");

        // Enable knife
        knife.SetActive(true);
    }
}
