using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Vector3 positionToTheSide = new Vector3(0, 0, -2f);
    int index = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // If empty inventory
            if (transform.childCount == 0)
                return;

            if (index != transform.childCount)
                HideCurrentItem();
            
            // Next index
            index++;
            if (index > transform.childCount)
                index = 0;

            // Show nothing
            if (index == transform.childCount)
                return; 
            
            ShowNextItem();
        }
    }
    public GameObject GetCurrentItem()
    {
        if (index >= transform.childCount)
            return null;
        return transform.GetChild(index).gameObject;
    }
    public void DestoryCurrentItem()
    {
        Destroy(transform.GetChild(index).gameObject);
        index = 0;
    }
    void HideCurrentItem()
    {
        transform.GetChild(index).localPosition = positionToTheSide;
    }
    void ShowNextItem()
    {
        transform.GetChild(index).localPosition = Vector3.zero;
    }
    void Start()
    {
        instance = this;
    }
    public static PlayerInventory instance;
}
