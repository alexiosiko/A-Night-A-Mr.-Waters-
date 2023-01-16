using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspectable : Interactable
{
    [SerializeField] string description;
    [SerializeField] float alertTime = 3f;
    public override void Action()
    {
        CanvasManager.instance.Alert(description, alertTime);
    }
    void Start()
    {
        cursorIndex = 5;
    }
}
