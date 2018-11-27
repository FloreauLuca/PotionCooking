using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Souris : MonoBehaviour
{
    // Utilisable dans futurs versions
    [SerializeField] [Range(0, 2)] private float sensitivity = 0.5f;

	void Start ()
	{

	    Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update () {

	    
        gameObject.transform.Translate(Input.GetAxis("Mouse X")*sensitivity, Input.GetAxis("Mouse Y")*sensitivity, 0);
        
    }
}
