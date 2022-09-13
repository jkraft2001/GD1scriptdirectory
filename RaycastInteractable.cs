﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaycastInteractable : MonoBehaviour
{
    public UnityEvent onInteract;
    
    public void DoInteraction()
    {
        onInteract.Invoke();
    }
}
