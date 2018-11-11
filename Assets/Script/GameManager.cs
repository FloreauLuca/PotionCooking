using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public enum WindowType
    {
        HOME,
        INGREDIENT,
        BAKING,
        PRESENTATION,
    };

    private WindowType currentWindow;

    [SerializeField]private GameObject currentCamera = null;
    private int UiButtonId = 0;
	// Use this for initialization
	void Start () {

    currentWindow = WindowType.HOME;

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
	        currentCamera.transform.position = new Vector3(0f, 0f, -10f);
	        UiButtonId = 0;
        }

	    if (Input.GetButtonDown("Second") || UiButtonId == 2)
	    {
	        currentWindow = WindowType.BAKING;
	        currentCamera.transform.position = new Vector3(5.75f, 0f, -10f);
	        UiButtonId = 0;
        }

	    if (Input.GetButtonDown("Third") || UiButtonId == 3)
	    {
	        currentWindow = WindowType.PRESENTATION;
	        currentCamera.transform.position = new Vector3(11.5f, 0f, -10f);
	        UiButtonId = 0;
	    }

	    if (Input.GetButtonDown("Four") || UiButtonId == 4)
	    {
	        currentWindow = WindowType.HOME;
	        currentCamera.transform.position = new Vector3(17.5f, 0f, -10f);
	        UiButtonId = 0;
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
                currentCamera.transform.position = new Vector3(0f, 0f, -10f);
                break;
            }
            case WindowType.INGREDIENT:
            {
                currentWindow = WindowType.BAKING;
                currentCamera.transform.position = new Vector3(5.75f, 0f, -10f);
                break;
            }
            case WindowType.BAKING:
            {
                currentWindow = WindowType.PRESENTATION;
                currentCamera.transform.position = new Vector3(11.5f, 0f, -10f);
                break;
            }
            case WindowType.PRESENTATION:
            {
                currentWindow = WindowType.HOME;
                currentCamera.transform.position = new Vector3(17.5f, 0f, -10f);
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
                currentCamera.transform.position = new Vector3(17.5f, 0f, -10f);
                break;
            }
            case WindowType.BAKING:
            {
                currentWindow = WindowType.INGREDIENT;
                currentCamera.transform.position = new Vector3(0f, 0f, -10f);
                break;
            }
            case WindowType.PRESENTATION:
            {
                currentWindow = WindowType.BAKING;
                currentCamera.transform.position = new Vector3(5.75f, 0f, -10f);
                break;
            }
            case WindowType.HOME:
            {
                currentWindow = WindowType.PRESENTATION;
                currentCamera.transform.position = new Vector3(11.5f, 0f, -10f);
                break;
            }
        }
    }

    public void UIButtonDown(int UIbutton)
    {
        UiButtonId = UIbutton;
    }

    public void NewCustomer()
    {

    }
}
