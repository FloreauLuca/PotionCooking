using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour {

    public List<string> currentContainObjectType;
    private GameObject gameManager;

    // Use this for initialization
    void Start ()
    {
        currentContainObjectType = new List<string>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDropObject(List<string> objectType)
    {
        currentContainObjectType.AddRange(objectType);
        Debug.Log("Drop");
    }

}
