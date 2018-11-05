using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDargged;

    private Vector3 startPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    #region IBeginDragHandler implemantation
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDargged = gameObject;
        startPosition = transform.position;
    }
    #endregion
    #region IBeginDragHandler implemantation
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    #endregion
    #region IBeginDragHandler implemantation
    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDargged = null;
        transform.position = startPosition;
    }
    #endregion
}
