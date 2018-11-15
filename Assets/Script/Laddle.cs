using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laddle : Draggable
{
    private Container cauldronContainer;
    private Cauldron cauldron;

    protected override void Start()
    {
        base.Start();
        cauldronContainer = GetComponentInParent<Container>();
        cauldron = GetComponentInParent<Cauldron>();
        containerType = "Cup";
    }

    void OnMouseDown()
    {
        ObjectType = cauldronContainer.CurrentContainObjectType;
        if (ObjectType[0])
        {
            Fill(ObjectType[0]);
        }
        else
        {
            Empty();
        }
    }

    public override void DropEmpty()
    {
        transform.position = starTransform;
    }

    public override void Drop(GameObject container)
    {
        container.GetComponent<Cup>().Fill(ObjectType[0]);
        transform.position = starTransform;

        cauldron.SetContainerNull();
    }
}
