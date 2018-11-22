using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

 

    public override void DropEmpty()
    {
        transform.position = starTransform;
    }

    public override void Drop(GameObject container)
    {
        base.Drop(container);
        container.GetComponent<Cup>().Fill(ObjectType[0]);
        transform.position = starTransform;

        cauldron.SetContainerNull();
    }
    
    void OnMouseDown()
    {
        ObjectType = cauldronContainer.CurrentContainObjectType;
        Debug.Log(ObjectType.Any());
        if (ObjectType.Any())
        {
            Fill(ObjectType[0]);
        }
        else
        {
            Empty();
        }
    }
}
