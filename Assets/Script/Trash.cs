using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private Cauldron cauldron;

    private GameObject gameManager;

	void Start ()
	{
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
	    cauldron = GetComponentInParent<Cauldron>();
	}
	
    private void OnMouseDown()
    {
        if (gameManager.GetComponent<GameManager>().Unpaused)
        {
            cauldron.SetContainerNull();
        }
    }
}
