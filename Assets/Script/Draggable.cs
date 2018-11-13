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

    [NonSerialized]private bool dragging = false;

    private bool table;



    [SerializeField] private Sprite potionInvisibility;
    [SerializeField] private Sprite potionLevitation;
    [SerializeField] private Sprite potionMetamorphose;
    private Sprite emptyCup;
    protected SpriteRenderer spriteRenderer;


    private Animator animator;


    // Use this for initialization
    public bool Dragging
    {
        get { return dragging; }
        set { dragging = value; }
    }
    public List<Sprite> ObjectType
    {
        get { return objectType; }
        set { objectType = value; }
    }
    protected virtual void Start ()
    {

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        emptyCup = spriteRenderer.sprite;
        starTransform = GetComponent<Transform>().position;
        container = GetComponent<Container>();
        box = GetComponent<BoxCollider2D>();
        objectType = new List<Sprite>();
        objectType.Add(GetComponentInChildren<SpriteRenderer>().sprite);
    }
    	
	// Update is called once per frame
	protected virtual void Update () {
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
	        bool dropped = false;
	        dragging = false;
	        //Debug.Log(transform.position);
	        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, box.size, 0, raycastLayerMask);

	        foreach (Collider2D collider in colliders)
	        {
	            if (collider != null && collider.gameObject != gameObject)
                { 
	                if (collider.tag == containerType)
	                {
	                    Debug.Log(collider);
	                    collider.GetComponent<Container>().OnDropObject(objectType);
	                    Drop(collider.gameObject);
	                    dropped = true;
	                    break;
	                }

	                if (collider.tag == "Table")
	                {
	                    table = true;
	                }
                }
            }

	        if (!table && !dropped)
	        {
	            DropEmpty();
	        }
	        else
	        {
	            table = false;
	        }
	    }
    }
    private void OnMouseDrag()
    {
        dragging = true;
    }


    public virtual void Drop(GameObject container) { }

    public virtual void DropEmpty() { }



    public void Fill(Sprite potion)
    {
        if (potion.name == "PotionInvisibility")
        {
            spriteRenderer.sprite = potionInvisibility;
        }
        if (potion.name == "PotionLevitation")
        {
            spriteRenderer.sprite = potionLevitation;
        }
        if (potion.name == "PotionMetamorphose")
        {
            spriteRenderer.sprite = potionMetamorphose;
        }
    }

    public void Empty()
    {
        spriteRenderer.sprite = emptyCup;
    }
}
