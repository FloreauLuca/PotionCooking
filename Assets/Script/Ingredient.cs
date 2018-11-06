﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : Draggable {

    // Use this for initialization
    protected override void Start ()
	{
        base.Start();
	    containerType = "Cauldron";
	}
	
    public override void Drop()
    {
        Destroy(gameObject);
    }
}
