using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : Draggable
{

    // Use this for initialization
    protected override void Start () {
	    base.Start();
        containerType = "Customer";
    }

    public override void DropEmpty()
    {
        transform.position = starTransform;
        Empty();
    }

    public override void Drop(GameObject container)
    {
        transform.position = starTransform;
    }

}
