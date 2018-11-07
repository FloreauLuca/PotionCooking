using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laddle : Draggable
{
    private Container cauldronContainer;


    protected override void Start()
    {
        base.Start();
        cauldronContainer = GetComponentInParent<Container>();
        containerType = "Cup";
    }

    void OnMouseDown()
    {
        ObjectType = cauldronContainer.CurrentContainObjectType;
    }

    public override void Drop()
    {
        transform.position = starTransform;
    }
}
