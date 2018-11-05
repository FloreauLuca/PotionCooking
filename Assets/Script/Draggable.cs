using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Draggable : MonoBehaviour
{
    private GameObject gameManager;

    public List<string> objectType;

    [SerializeField] private float raycastRadius = 0.25f;

    [SerializeField] private LayerMask raycastLayerMask;
    protected string containerType;
    private BoxCollider2D box;
    private Container container;
    protected Vector2 starTransform;
    // Use this for initialization
    protected virtual void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

        starTransform = GetComponent<Transform>().position;
        container = GetComponent<Container>();
        box = GetComponent<BoxCollider2D>();
    }
    	
	// Update is called once per frame
	void Update () {
	    if (container != null)
	    {
	        objectType = container.currentContainObjectType;
	    }
        

    }
    void OnMouseDrag()
    {
        //Debug.Log("yousk2");
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.z = 0;
        gameObject.transform.position = point;
        
    }
    

    private void OnMouseUp()
    {
        Debug.Log(transform.position);
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, box.size, 0, raycastLayerMask);
        
        foreach (Collider2D collider in colliders)
        {
            Debug.Log(collider.name);
            if (collider != null && collider.gameObject != gameObject)
            {
                if (collider.tag == containerType)
                {
                    Debug.Log(containerType);
                    collider.GetComponent<Container>().OnDropObject(objectType);
                    Drop();
                    break;
                }
            }
        }
    }

    public virtual void Drop()
    {

    }
}
