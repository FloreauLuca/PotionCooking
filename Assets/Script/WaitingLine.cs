﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingLine : MonoBehaviour
{
    [SerializeField] private GameObject otherLine;
    [SerializeField] private List<GameObject> customers;

    [SerializeField] private bool welcomedCustomer = false;

    [SerializeField] private float space;

   

    public GameObject OtherLine
    {
        get { return otherLine; }
        set { otherLine = value; }
    }

    public List<GameObject> Customers
    {
        get
        {
            return customers;
        }
        set
        {
            customers = value; 
        }
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LineOrganization()
    {
        for (int customerIndex = 0; customerIndex < customers.Count; customerIndex++)
        {
            customers[customerIndex].transform.position = transform.position + Vector3.right * customerIndex * space;
        }

    }

    public void NewCustomer(GameObject customer, SO_Potion potion)
    {
        GameObject newCustomer = Instantiate(customer, transform);
        newCustomer.GetComponent<Customer>().Potion = potion;
        Debug.Log("CreateCustomer");
    }


}