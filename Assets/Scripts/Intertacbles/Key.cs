using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    [SerializeField] string keyName = "";
    public override void Action()
    {
        InventoryManager.instance.AddItem(keyName);
        Destroy(gameObject);
    }
}
