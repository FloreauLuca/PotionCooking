using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public string[] currentContainObjectType;
    private GameObject gameManager;

    private GameObject dropObject;
    // Use this for initialization
    void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseUp()
    {
        Debug.Log("Debug");
        dropObject = gameManager.GetComponent<GameManager>().currentObject;
        currentContainObjectType.SetValue(dropObject.GetComponent<Draggable>().objectType, currentContainObjectType.Length+1);
        Destroy(dropObject);
    }
}
