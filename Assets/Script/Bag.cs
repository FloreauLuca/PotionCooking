using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    [SerializeField] private GameObject objectprefab;

    private GameObject spawnObject;
    private void OnMouseDown()
    {
       spawnObject = Instantiate(objectprefab, transform);
       spawnObject.GetComponent<Ingredient>().dragging = true;
    }
   
}
