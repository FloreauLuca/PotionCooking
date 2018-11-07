using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Draggable : MonoBehaviour
{

    [SerializeField] private List<Sprite> objectType;

    [SerializeField] private LayerMask raycastLayerMask;
    protected string containerType;
    private BoxCollider2D box;
    private Container container;
    protected Vector2 starTransform;

    [NonSerialized]public bool dragging = false;

    private bool table;
    // Use this for initialization

    public List<Sprite> ObjectType
    {
        get { return objectType; }
        set { objectType = value; }
    }
    protected virtual void Start ()
    {

        starTransform = GetComponent<Transform>().position;
        container = GetComponent<Container>();
        box = GetComponent<BoxCollider2D>();
        objectType = new List<Sprite>();
        objectType.Add(GetComponentInChildren<SpriteRenderer>().sprite);
    }
    	
	// Update is called once per frame
	void Update () {
	    if (container != null)
	    {
	        objectType = container.CurrentContainObjectType;
	    }

	    if (dragging)
	    {

	        //Debug.Log("yousk2");
	        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	        point.z = 0;
	        gameObject.transform.position = point;

        }

	    if (Input.GetMouseButtonUp(0) && dragging)
	    {
	        dragging = false;
	        //Debug.Log(transform.position);
	        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, box.size, 0, raycastLayerMask);

	        foreach (Collider2D collider in colliders)
	        {
	            //Debug.Log(collider.name);
	            if (collider != null && collider.gameObject != gameObject)
	            {
	                if (collider.tag == containerType)
	                {
	                    //Debug.Log(containerType);
	                    collider.GetComponent<Container>().OnDropObject(objectType);
	                    Drop();
	                    break;
	                }

	                if (collider.tag == "Table")
	                {
	                    table = true;
	                }
                }
            }

	        if (!table)
	        {
	            Drop();
	        }
	        else
	        {
	            table = false;
	        }
	    }
    }
    public void OnMouseDrag()
    {
        dragging = true;
    }


    public virtual void Drop() { }
}
