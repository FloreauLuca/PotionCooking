using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour
{
    private int option;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {


	    if (Input.GetButtonDown("Cancel"))
	    {
	        Quit();

	    }

    }


    public void Quit()
    {
        Application.Quit();
        //EditorApplication.isPlaying = false;
    }
}
