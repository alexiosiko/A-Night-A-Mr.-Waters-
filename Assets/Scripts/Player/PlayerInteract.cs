using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    private float reachDistance = 2.3f;
    void Update()
    {
        // Debug
        Debug.DrawLine(cameraPosition.position, cameraPosition.position + cameraPosition.transform.forward * reachDistance, Color.green);

        // If currently hiding
        if (Input.GetKeyDown(KeyCode.E) && StatusManager.instance.currentHiddenGameObject != null)
            StatusManager.instance.currentHiddenGameObject.GetComponent<Hideable>().ExitHide();
        
        // Get interact input
        else if (Input.GetKeyDown("e") && StatusManager.instance.freeze == false
            || Input.GetMouseButtonDown(0) && StatusManager.instance.freeze == false)
            Interact();

        // Highlight object
        Highlight();
    }
    void Highlight()
    {
        if (Physics.Raycast(cameraPosition.position, cameraPosition.transform.forward, out RaycastHit hit, reachDistance))
        {
            Interactable i = hit.collider.GetComponentInParent<Interactable>();
            if (i != null)
                StatusManager.instance.ChangeCrosshair(i.cursorIndex);
            else
                StatusManager.instance.ChangeCrosshair(0);
        }
        else
            StatusManager.instance.ChangeCrosshair(0);
    }
    void Interact()
    {
        if (Physics.Raycast(cameraPosition.position, cameraPosition.transform.forward, out RaycastHit hit, reachDistance))
        {
            Interactable i = hit.collider.GetComponentInParent<Interactable>();
            if (i != null)
                i.Action();
        }
    }

    public Transform cameraPosition;
}
