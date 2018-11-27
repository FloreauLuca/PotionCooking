using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquide : Draggable{

    protected override void Start()
    {
        base.Start();
        containerType = "Cauldron";
    }

    public override void DropEmpty()
    {
        transform.position = starTransform;
    }

    public override void Drop(GameObject container)
    {
        base.Drop(container);
        animator.SetTrigger("Pouring");
        transform.position = starTransform;
    }
}
