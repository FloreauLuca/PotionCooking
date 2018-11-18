using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    [SerializeField] private GameObject objectprefab;

    private GameObject spawnObject;

    private GameObject mousePrefab;

    void Start()
    {
        mousePrefab = GameObject.FindGameObjectWithTag("Mouse");
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.GetComponent<BoxCollider2D>().OverlapPoint(mousePrefab.transform.position))
            {
                spawnObject = Instantiate(objectprefab, transform);
                spawnObject.GetComponent<Ingredient>().Dragging = true;
            }
        }
    }

}
