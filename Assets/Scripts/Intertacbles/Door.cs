using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public bool locked = false;
    public string keyName = "";
    bool opened = false;
    public override void Action()
    {
        if (locked == false) // Is not locked
        {
            if (opened == false) // Open door
            {
                animator.Play("Open");
                Invoke("ChangeDoorStatus", 0.4f); // 0.4f is door animation time
            }
            else // Close door
            {
                animator.Play("Close");
                Invoke("ChangeDoorStatus", 0.4f); // 0.4f is door animation time
            }
        }
        else // Try and unlock
        {
            if (InventoryManager.instance.GetItem(keyName) == true)
            {
                // Unlock
                locked = false;
            }
            else // Wiggle door
            {
                
            }
        }
    }
    void ChangeDoorStatus()
    {
        if (opened == true)
            opened = false;
        else
            opened = true;
    }
    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }
    Animator animator;
}
