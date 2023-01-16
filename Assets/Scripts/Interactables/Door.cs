using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Door : Interactable
{
    public bool locked = false;
    public string keyName = "";
    public bool opened = false;
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
            GameObject currentItem = PlayerInventory.instance.GetCurrentItem();
            
            // If empty hand, do NOTHING    
            if (currentItem == null)
            {
                if (keyName != "")
                    CanvasManager.instance.Alert("This door requires " + keyName + " ...");
                else
                    CanvasManager.instance.Alert("This door won't budge ...");  
                return;
            }

            Collectable collectable = currentItem.GetComponent<Collectable>();
            if (collectable.itemId == keyName)
            {
                // Unlock
                locked = false;

                // Delete item
                PlayerInventory.instance.DestoryCurrentItem();
                
                // Canvas
                CanvasManager.instance.Alert("This key fits!");
            }
            else // Wiggle door
            {
                if (keyName != null)
                    CanvasManager.instance.Alert("This door requires " + keyName + " ...");
                else
                    CanvasManager.instance.Alert("This door won't budge ...");
            }
        }
    }
    public void Unlock()
    {
        locked = false;
    }
    public void OpenDoor()
    {
        if (locked == true || opened == true)
            return;
        
        animator.Play("Open");
        Invoke("ChangeDoorStatus", 0.4f); // 0.4f is door animation time
        
    }
    void ChangeDoorStatus()
    {
        if (opened == true)
        {
            opened = false;

            // This is for AI for owner
            nav.carving = false;
        }
        else
        {            
            opened = true;

            // This is for AI for owner
            nav.carving = true;
        }
    }
    void Awake()
    {
        animator = GetComponentInParent<Animator>();
        cursorIndex = 4;
        nav = GetComponent<NavMeshObstacle>();
    }
    NavMeshObstacle nav;
    Animator animator;
}
