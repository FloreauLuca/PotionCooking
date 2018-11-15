using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCustomer : MonoBehaviour {

    [SerializeField] private GameObject[] customersPrefab;
    [SerializeField] private SO_Potion[] potionPrefab;
    [SerializeField] private WaitingLine waitingLine;

    [SerializeField] private float timeBetweenCustomer;

    [SerializeField] private int totalNumberCustomer;

    private GameObject gameManager;

    private int currentNumberCustomer = 0;
    private int servedCustomer = 0;
    private int unservedCustomer = 0;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        StartCoroutine(WaitAndSummon());
    }
	
	// Update is called once per frame
	void Update () {

	    if (unservedCustomer + servedCustomer == totalNumberCustomer)
	    {
	        gameManager.GetComponent<GameManager>().End(servedCustomer, totalNumberCustomer);
	    }


    }

    public void SpawnCustomers()
    {
        waitingLine.NewCustomer(customersPrefab[Random.Range(0, customersPrefab.Length)], potionPrefab[Random.Range(0, potionPrefab.Length)]);
        Debug.Log("New Customer");
    }

    IEnumerator WaitAndSummon()
    {
        SpawnCustomers();
        currentNumberCustomer++;
        yield return new WaitForSeconds(timeBetweenCustomer);
        if (currentNumberCustomer < totalNumberCustomer)
        {
            StartCoroutine(WaitAndSummon());
        }
    }

    public void HappyCustomer()
    {
        servedCustomer++;
    }

    public void MadCustomer()
    {
        unservedCustomer++;
    }
}
