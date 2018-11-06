using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    [SerializeField] private GameObject objectprefab;

    private GameObject spawnObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
       spawnObject = Instantiate(objectprefab, transform);
       spawnObject.GetComponent<Ingredient>().dragging = true;
    }
   
}
