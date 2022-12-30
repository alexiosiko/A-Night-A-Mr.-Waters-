using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hideable : Interactable
{
    public override void Action()
    {
        if (StatusManager.instance.currentHiddenGameObject == null)
            EnterHide();
    }
    
    
    public void ExitHide()
    {
        // Enable player collider
        playerCollider.enabled = true;

        // Change crosshair
        StatusManager.instance.ChangeCrosshair(0);

        // Change status
        StatusManager.instance.Unfreeze(0.75f);
        StatusManager.instance.currentHiddenGameObject = null;
    
         // Animate camera
        // Camera.main.transform.DOLocalMove(Vector3.zero, 0.75f);
        // Camera.main.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.75f);

        // Animate player
        player.transform.DOMove(beforeHidePosition, 0.75f);
        // player.transform.DORotate(beforeHideRotation + new Vector3(0, 180, 0), 0.75f);
    }
    Vector3 beforeHidePosition;
    Vector3 beforeHideRotation;
    void EnterHide()
    {
        // Store beforeHidePosition
        beforeHidePosition = player.transform.position;
        beforeHideRotation = player.transform.eulerAngles;

        // Disable player collider
        playerCollider.enabled = false;

        // Change crosshair
        StatusManager.instance.ChangeCrosshair(3);

        // Change status
        StatusManager.instance.freeze = true;
        StatusManager.instance.currentHiddenGameObject = gameObject;

        // Animate camera
        // Camera.main.transform.DOMove(spot.position, 0.75f);
        // Camera.main.transform.DORotate(spot.eulerAngles, 0.75f);

        // Animate player
        player.transform.DOMove(spot.position, 0.75f);
        // player.transform.DORotate(spot.eulerAngles, 0.75f);
    }

    void Start()
    {
        playerCollider = GameObject.FindWithTag("Player").GetComponent<Collider>();
        spot = transform.GetChild(0).transform;
        player = GameObject.FindWithTag("Player").transform;
    }
    Transform player;
    Transform spot;
    Collider playerCollider;
}
