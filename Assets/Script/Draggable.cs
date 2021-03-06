﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Draggable : MonoBehaviour
{

    [SerializeField] private List<Sprite> objectType;
    public List<Sprite> ObjectType
    {
        get { return objectType; }
        set { objectType = value; }
    }

    [SerializeField] private LayerMask raycastLayerMask;
    protected string containerType;
    private BoxCollider2D box;
    private Container container;
    protected Vector2 starTransform;

    private bool dragging = false;
    public bool Dragging
    {
        get { return dragging; }
        set { dragging = value; }
    }

    private bool table;

    private GameObject gameManager;

    [SerializeField] private Sprite potionInvisibility;
    [SerializeField] private Sprite potionLevitation;
    [SerializeField] private Sprite potionMetamorphose;
    private Sprite emptyCup;
    protected SpriteRenderer spriteRenderer;

    protected Animator animator;

    [SerializeField] private AudioClip audioClip;
    
    protected virtual void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        emptyCup = spriteRenderer.sprite;
        starTransform = GetComponent<Transform>().position;
        container = GetComponent<Container>();
        box = GetComponent<BoxCollider2D>();
        objectType = new List<Sprite>();
        objectType.Add(GetComponentInChildren<SpriteRenderer>().sprite);
    }
    	
	protected virtual void Update () {
	    if (container != null)
	    {
	        objectType = container.CurrentContainObjectType;
	    }

	    if (dragging)
	    {
	        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	        point.z = 0;
	        gameObject.transform.position = point;

        }

	    if (Input.GetMouseButtonUp(0) && dragging)
	    {
	        bool dropped = false;
	        dragging = false;
	        Collider2D[] colliders = Physics2D.OverlapBoxAll((Vector2)transform.position+box.offset, box.size, 0, raycastLayerMask);

	        foreach (Collider2D collider in colliders)
	        {
	            if (collider != null && collider.gameObject != gameObject)
                { 
	                if (collider.tag == containerType)
	                {
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
        if (gameManager.GetComponent<GameManager>().Unpaused)
        {
            dragging = true;
        }
    }


    public virtual void Drop(GameObject container)
    {
        container.GetComponent<AudioSource>().clip = audioClip;
        container.GetComponent<AudioSource>().Play();
    }

    public virtual void DropEmpty() { }

    public void Fill(Sprite potion)
    {
        if (potion.name == "PotionInvisibility")
        {
            spriteRenderer.sprite = potionInvisibility;
        } else
        if (potion.name == "PotionLevitation")
        {
            spriteRenderer.sprite = potionLevitation;
        } else
        if (potion.name == "PotionMetamorphose")
        {
            spriteRenderer.sprite = potionMetamorphose;
        }
        else
        {
            Empty();
        }
    }

    public void Empty()
    {
        spriteRenderer.sprite = emptyCup;
    }
}
