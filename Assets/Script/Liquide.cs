using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquide : Draggable{
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        containerType = "Cauldron";
    }
    

    public override void Drop()
    {
        transform.position = starTransform;
    }
}
