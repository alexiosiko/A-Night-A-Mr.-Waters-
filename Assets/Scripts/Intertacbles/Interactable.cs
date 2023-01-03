using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [HideInInspector] public int cursorIndex = 0;
    public virtual void Action() {}
}