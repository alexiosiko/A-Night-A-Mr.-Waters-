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
        // Enable collider
        // GetComponent<Collider>().enabled = true;

        // Change crosshair
        StatusManager.instance.ChangeCrosshair(0);

        // Animate camera
        Camera.main.transform.DOLocalMove(Vector3.zero, 0.75f);
        Camera.main.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.75f);

        // Change status
        StatusManager.instance.Unfreeze(0.75f);
        StatusManager.instance.currentHiddenGameObject = null;
    }
    void EnterHide()
    {
        // Disable collider
        // GetComponent<Collider>().enabled = false;
        
        // Change crosshair
        StatusManager.instance.ChangeCrosshair(3);

        // Change status
        StatusManager.instance.freeze = true;
        StatusManager.instance.currentHiddenGameObject = gameObject;

        // Animate camera
        Camera.main.transform.DOMove(spot.position, 0.75f);
        Camera.main.transform.DORotate(spot.eulerAngles, 0.75f);
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        spot = transform.GetChild(0).transform;
    }
    Transform spot;
    public Transform player;
}
