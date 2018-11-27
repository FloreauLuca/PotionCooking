using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingLine : MonoBehaviour
{
    [SerializeField] private GameObject otherLine;
    public GameObject OtherLine
    {
        get { return otherLine; }
        set { otherLine = value; }
    }

    [SerializeField] private List<GameObject> customers;
    public List<GameObject> Customers
    {
        get { return customers; }
        set { customers = value; }
    }

    [SerializeField] private float waitingDistance;

    private float space = 0;

    public void LineOrganization()
    {
        if (customers.Count != 0)
        {
            space = waitingDistance / (float)customers.Count;
        }
        for (int customerIndex = 0; customerIndex < customers.Count; customerIndex++)
        {
            customers[customerIndex].transform.position = transform.position + Vector3.right * customerIndex * space;
        }
    }

    public void NewCustomer(GameObject customer, SO_Potion potion)
    {
        GameObject newCustomer = Instantiate(customer, transform);
        newCustomer.GetComponent<Customer>().Potion = potion;
    }


}
