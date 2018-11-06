using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cauldron : MonoBehaviour
{
    private Container container;
    [SerializeField] private GameObject[] item;
    [SerializeField] private Sprite[,] recipe;

    void Start ()
    {
        container = GetComponent<Container>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (container.currentContainObjectType.Count == 3)
	    {
	        if (container.currentContainObjectType[0].name == "")
	        {
                recipe = new Sprite[1,1];
	        }

	        container.currentContainObjectType = new List<Sprite>();
	        for (int i = 0; i < 3; i++)
	        {
	            item[i].GetComponentInChildren<SpriteRenderer>().sprite = null;
	        }
        }

	    for (int i = 0; i < container.currentContainObjectType.Count; i++)
	    {
	        item[i].GetComponentInChildren<SpriteRenderer>().sprite = container.currentContainObjectType[i];
	    }
	}

}
