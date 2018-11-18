using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Souris : MonoBehaviour
{

    private float sensitivity = 0.5f;

    private GlobalGameManager globalGameManager;
    void Start()
    {
        globalGameManager = GameObject.FindGameObjectWithTag("GlobalGameManager").GetComponent<GlobalGameManager>();
    }


    // Update is called once per frame
    void Update ()
    {
        sensitivity = globalGameManager.Sensitivity;
        gameObject.transform.Translate(Input.GetAxis("Mouse X")*sensitivity, Input.GetAxis("Mouse Y")*sensitivity, 0);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
    }
}
