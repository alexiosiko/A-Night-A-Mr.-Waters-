using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    public Sprite[] crosshairs; // List of crosshair sprites
    public Image cursor; // The image for the CURRENT cursor
    public bool freeze = false; // Freezes character
    public GameObject currentHiddenGameObject = null; // Which GameObject we are currently hiding in
    public static StatusManager instance;
    void Awake()
    {
        instance = this;
    }
    public void ChangeCrosshair(int index)
    {
        if (freeze == true)
            return;
        // print("Changing crosshair to " + index);
        cursor.sprite = crosshairs[index];
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Unfreeze(float delay)
    {
        Invoke("UnFreezeNow", delay);
    }
    void UnFreezeNow()
    {
        freeze = false;
    }
}
