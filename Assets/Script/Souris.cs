using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Souris : MonoBehaviour
{

    [SerializeField] [Range(0, 2)] private float sensitivity = 0.5f;
	// Use this for initialization
	void Start ()
	{

	    Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

	    
        gameObject.transform.Translate(Input.GetAxis("Mouse X")*sensitivity, Input.GetAxis("Mouse Y")*sensitivity, 0);
        
    }
}
