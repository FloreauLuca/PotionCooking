using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    private int uiButtonId = 0; // Connaitre le bouton appuyer
    public int UiButtonId
    {
        get { return uiButtonId; }
        set { uiButtonId = value; }
    }

    [SerializeField] private GameObject[] signText;

    private GameObject gameManager;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        currentWindow = WindowType.HOME;
    }
	
	// Update is called once per frame
	void Update () {
	    if (gameManager.GetComponent<GameManager>().Unpaused)
	    {
	        if (Input.GetButtonDown("Space"))
	        {
	            Switch();
	        }


	        if (Input.GetButtonDown("First") || UiButtonId == 1)
	        {
	            currentWindow = WindowType.INGREDIENT;
	            transform.position = new Vector3(0f, 0f, -10f);
	            foreach (GameObject text in signText)
	            {
	                text.GetComponent<TextMeshProUGUI>().color = Color.black;
	            }

	            signText[0].GetComponent<TextMeshProUGUI>().color = Color.white;
	            uiButtonId = 0;
	        }

	        if (Input.GetButtonDown("Second") || UiButtonId == 2)
	        {
	            currentWindow = WindowType.BAKING;
	            transform.position = new Vector3(6.75f, 0f, -10f);
	            foreach (GameObject text in signText)
	            {
	                text.GetComponent<TextMeshProUGUI>().color = Color.black;
	            }

	            signText[1].GetComponent<TextMeshProUGUI>().color = Color.white;
	            uiButtonId = 0;
	        }

	        if (Input.GetButtonDown("Third") || UiButtonId == 3)
	        {
	            currentWindow = WindowType.PRESENTATION;
	            transform.position = new Vector3(13.5f, 0f, -10f);
	            foreach (GameObject text in signText)
	            {
	                text.GetComponent<TextMeshProUGUI>().color = Color.black;
	            }

	            signText[2].GetComponent<TextMeshProUGUI>().color = Color.white;
	            uiButtonId = 0;
	        }

	        if (Input.GetButtonDown("Four") || UiButtonId == 4)
	        {
	            currentWindow = WindowType.HOME;
	            transform.position = new Vector3(20.25f, 0f, -10f);
	            foreach (GameObject text in signText)
	            {
	                text.GetComponent<TextMeshProUGUI>().color = Color.black;
	            }

	            signText[3].GetComponent<TextMeshProUGUI>().color = Color.white;
	            uiButtonId = 0;
	        }

	    }

	}

    public void Switch()
    {
        
        switch (currentWindow)
        {
            case WindowType.HOME:
                {
                    currentWindow = WindowType.INGREDIENT;
                    transform.position = new Vector3(0f, 0f, -10f);
                    signText[0].GetComponent<TextMeshProUGUI>().color = Color.white;
                    signText[3].GetComponent<TextMeshProUGUI>().color = Color.black;
                    break;
                }
            case WindowType.INGREDIENT:
                {
                    currentWindow = WindowType.BAKING;
                    transform.position = new Vector3(6.75f, 0f, -10f);
                    signText[1].GetComponent<TextMeshProUGUI>().color = Color.white;
                    signText[0].GetComponent<TextMeshProUGUI>().color = Color.black;
                    break;
                }
            case WindowType.BAKING:
                {
                    currentWindow = WindowType.PRESENTATION;
                    transform.position = new Vector3(13.5f, 0f, -10f);
                    signText[2].GetComponent<TextMeshProUGUI>().color = Color.white;
                    signText[1].GetComponent<TextMeshProUGUI>().color = Color.black;
                    break;
                }
            case WindowType.PRESENTATION:
                {
                    currentWindow = WindowType.HOME;
                    transform.position = new Vector3(20.25f, 0f, -10f);
                    signText[3].GetComponent<TextMeshProUGUI>().color = Color.white;
                    signText[2].GetComponent<TextMeshProUGUI>().color = Color.black;
                    break;
                }
        }
    }

    /*                                Utilisable dans de futur version
    public void SwitchDown()
    {
        
        switch (currentWindow)
        {
            case WindowType.INGREDIENT:
                {
                    currentWindow = WindowType.HOME;
                    transform.position = new Vector3(20.25f, 0f, -10f);
                    signText[3].GetComponent<TextMeshProUGUI>().color = Color.white;
                    signText[0].GetComponent<TextMeshProUGUI>().color = Color.black;
                    break;
                }
            case WindowType.BAKING:
                {
                    currentWindow = WindowType.INGREDIENT;
                    transform.position = new Vector3(0f, 0f, -10f);
                    signText[0].GetComponent<TextMeshProUGUI>().color = Color.white;
                    signText[1].GetComponent<TextMeshProUGUI>().color = Color.black;
                    break;
                }
            case WindowType.PRESENTATION:
                {
                    currentWindow = WindowType.BAKING;
                    transform.position = new Vector3(6.75f, 0f, -10f);
                    signText[1].GetComponent<TextMeshProUGUI>().color = Color.white;
                    signText[2].GetComponent<TextMeshProUGUI>().color = Color.black;
                    break;
                }
            case WindowType.HOME:
                {
                    currentWindow = WindowType.PRESENTATION;
                    transform.position = new Vector3(13.5f, 0f, -10f);
                    signText[2].GetComponent<TextMeshProUGUI>().color = Color.white;
                    signText[3].GetComponent<TextMeshProUGUI>().color = Color.black;
                    break;
                }
        }
    }*/


}
