using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private GameObject gameManager;

    public string objectType;
    // Use this for initialization
    void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
	
	// Update is called once per frame
	void Update () {

    }
    void OnMouseDrag()
    {
        Debug.Log("yousk2");
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.z = 0;
        gameObject.transform.position = point;
        
    }

    private void OnMouseDown()
    {
        gameManager.GetComponent<GameManager>().currentObject = gameObject;
    }

    private void OnMouseUp()
    {
        
    }
}
