using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : Draggable {

	// Use this for initialization
	protected override void Start () {
	    base.Start();
        containerType = "Customer";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Drop()
    {
        transform.position = starTransform;
    }
}
