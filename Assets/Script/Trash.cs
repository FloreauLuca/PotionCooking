using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private Cauldron cauldron;
    // Use this for initialization


    private GameObject mousePrefab;

    void Start ()
	{
	    mousePrefab = GameObject.FindGameObjectWithTag("Mouse");
        cauldron = GetComponentInParent<Cauldron>();
	}
    private void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.GetComponent<BoxCollider2D>().OverlapPoint(mousePrefab.transform.position))
            {
                cauldron.SetContainerNull();
            }
        }
    }
    
}
