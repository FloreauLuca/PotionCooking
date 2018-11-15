using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public enum SceneState
    {
        MAINMENU,
        TUTORIAL,
        GAME,
        WIN,
        PAUSE,
        OPTION
    }

    [SerializeField] private GameObject currentCamera = null;

    private SceneState currentSceneState = SceneState.MAINMENU;

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

        if (Input.GetButtonDown("Pause") && currentSceneState != SceneState.MAINMENU)
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
    }
}
