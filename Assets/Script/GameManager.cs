using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    

    [SerializeField] private GameObject currentCamera = null;


    [SerializeField] private GameObject canvasPause;
    [SerializeField] private GameObject canvasWin;
    [SerializeField] private GameObject scoreText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Pause"))
        {
            if (canvasPause.activeSelf)
            {
                canvasPause.SetActive(false);
            }
            else
            {
                canvasPause.SetActive(true);
            }
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();

        }
    }



    public void UIButtonDown(int uiButton)
    {
        currentCamera.GetComponent<CameraScript>().UiButtonId = uiButton;
    }


    public void End(int servedCustomer, int totalNumberCustomer)
    {
        Debug.Log("End");
        canvasWin.SetActive(true);
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score : " + servedCustomer + " / " + totalNumberCustomer;
    }
}
