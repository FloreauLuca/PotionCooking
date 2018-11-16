using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public enum WindowType
    {
        HOME,
        INGREDIENT,
        BAKING,
        PRESENTATION
    };


    private WindowType currentWindow;

    private CinemachineVirtualCamera cinemachine;

    private int uiButtonId = 0;

    public int UiButtonId
    {
        get { return uiButtonId; }
        set { uiButtonId = value; }
    }

    // Use this for initialization
    void Start () {

        currentWindow = WindowType.HOME;
        cinemachine = GetComponent<CinemachineVirtualCamera>();
    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetButtonDown("Space"))
        {
            Switch();
        }


        if (Input.GetButtonDown("First") || UiButtonId == 1)
        {
            currentWindow = WindowType.INGREDIENT;
            transform.position = new Vector3(0f, 0f, -10f);
            uiButtonId = 0;
        }

        if (Input.GetButtonDown("Second") || UiButtonId == 2)
        {
            currentWindow = WindowType.BAKING;
            transform.position = new Vector3(6.75f, 0f, -10f);
            uiButtonId = 0;
        }

        if (Input.GetButtonDown("Third") || UiButtonId == 3)
        {
            currentWindow = WindowType.PRESENTATION;
            transform.position = new Vector3(13.5f, 0f, -10f);
            uiButtonId = 0;
        }

        if (Input.GetButtonDown("Four") || UiButtonId == 4)
        {
            currentWindow = WindowType.HOME;
            transform.position = new Vector3(20.25f, 0f, -10f);
            uiButtonId = 0;
        }



    }

    public void Switch()
    {
        //Debug.Log("Switch");
        switch (currentWindow)
        {
            case WindowType.HOME:
                {
                    currentWindow = WindowType.INGREDIENT;
                    transform.position = new Vector3(0f, 0f, -10f);
                    break;
                }
            case WindowType.INGREDIENT:
                {
                    currentWindow = WindowType.BAKING;
                    transform.position = new Vector3(6.75f, 0f, -10f);
                    break;
                }
            case WindowType.BAKING:
                {
                    currentWindow = WindowType.PRESENTATION;
                    transform.position = new Vector3(13.5f, 0f, -10f);
                    break;
                }
            case WindowType.PRESENTATION:
                {
                    currentWindow = WindowType.HOME;
                    transform.position = new Vector3(20.25f, 0f, -10f);
                    break;
                }
        }
    }

    public void SwitchDown()
    {
        //Debug.Log("SwitchDown");
        switch (currentWindow)
        {
            case WindowType.INGREDIENT:
                {
                    currentWindow = WindowType.HOME;
                    transform.position = new Vector3(20.25f, 0f, -10f);
                    break;
                }
            case WindowType.BAKING:
                {
                    currentWindow = WindowType.INGREDIENT;
                    transform.position = new Vector3(0f, 0f, -10f);
                    break;
                }
            case WindowType.PRESENTATION:
                {
                    currentWindow = WindowType.BAKING;
                    transform.position = new Vector3(6.75f, 0f, -10f);
                    break;
                }
            case WindowType.HOME:
                {
                    currentWindow = WindowType.PRESENTATION;
                    transform.position = new Vector3(13.5f, 0f, -10f);
                    break;
                }
        }
    }


}
