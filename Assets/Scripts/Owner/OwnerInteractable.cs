using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnerInteractable : Interactable
{
    public string nameOfWeapon = "weapon";
    public override void Action()
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
            Destroy(gameObject);
        }
        
    }
}
