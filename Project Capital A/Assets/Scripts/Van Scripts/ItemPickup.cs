﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    void PickUp()
    {
        Debug.Log("Picked up  " + transform.name);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
