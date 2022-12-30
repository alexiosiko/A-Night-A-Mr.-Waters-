using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<string> items;
    void Awake()
    {
        instance = this;
    }
    public void AddItem(string itemName)
    {
        items.Add(itemName);
    }
    public bool GetItem(string itemName)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == itemName)
            {
                items.RemoveAt(i);
                return true;
            }
        }
        return false;
    }
}
