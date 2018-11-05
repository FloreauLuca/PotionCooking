using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cauldron : MonoBehaviour
{
    public string[] currentContainObjectType = new string[3];
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

    public void OnMouseOver()
    {
        Debug.Log("Debug");
        if (Input.GetMouseButtonUp(0))
        {
            
            dropObject = gameManager.GetComponent<GameManager>().currentObject;
            currentContainObjectType.SetValue(dropObject.GetComponent<Draggable>().objectType,currentContainObjectType.GetUpperBound(1)+1);
            Destroy(dropObject);
        }

    }

}
