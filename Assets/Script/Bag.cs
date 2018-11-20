using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    [SerializeField] private GameObject objectprefab;
    private GameObject gameManager;
    private GameObject spawnObject;
    private void OnMouseDown()
    {
        if (gameManager.GetComponent<GameManager>().Unpaused)
        {
            spawnObject = Instantiate(objectprefab, transform);
            spawnObject.GetComponent<Ingredient>().Dragging = true;
        }
    }

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
}
