using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private Cauldron cauldron;
	// Use this for initialization
	void Start ()
	{
	    cauldron = GetComponentInParent<Cauldron>();
	}
	
    private void OnMouseDown()
    {
        cauldron.SetContainerNull();
    }
}
