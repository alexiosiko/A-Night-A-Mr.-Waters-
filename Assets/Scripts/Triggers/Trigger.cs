using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Action();
    }
    protected virtual void Action()
    {
        collider.enabled = false;
    }
    protected virtual void Awake()
    {
        collider = GetComponent<Collider>();
    }
    new Collider collider;
}
