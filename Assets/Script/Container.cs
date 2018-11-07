using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour {

    public List<Sprite> currentContainObjectType;
    private GameObject gameManager;

    // Use this for initialization
    void Start ()
    {
        currentContainObjectType = new List<Sprite>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void OnDropObject(List<Sprite> objectType)
    {
        currentContainObjectType.AddRange(objectType);
        Debug.Log("Drop");
    }

}
