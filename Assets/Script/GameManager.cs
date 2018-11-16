using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject currentCamera = null;

    [SerializeField] private GameObject canvasPause;
    [SerializeField] private GameObject canvasWin;
    [SerializeField] private GameObject scoreText;

    [SerializeField] private GameObject winText;
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
    }



    public void UIButtonDown(int uiButton)
    {
        currentCamera.GetComponent<CameraScript>().UiButtonId = uiButton;
    }


    public void End(int servedCustomer, int totalNumberCustomer)
    {
        //Debug.Log("End");
        canvasWin.SetActive(true);
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score : " + servedCustomer + " / " + totalNumberCustomer;
        if (servedCustomer / totalNumberCustomer >= 1 / 2)
        {
            winText.GetComponent<TextMeshProUGUI>().text = "Win";
        }
        else
        {
            winText.GetComponent<TextMeshProUGUI>().text = "Loose";
        }
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
