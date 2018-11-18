using System.Collections;
using System.Collections.Generic;
using Cinemachine;
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

    private GlobalGameManager globalGameManager;


    [SerializeField] private GameObject cinemachineComposition;
    [SerializeField] private CinemachineBrain cinemachineBrain;

    private GameObject mousePrefab;

    private GameObject customerChoose = null;

    public GameObject CustomerChoose // Pour vérifier si le button down à déjà été appuier sur un objey
    {
        get { return customerChoose; }
        set { customerChoose = value; }
    }
    // Use this for initialization
    void Start()
    {
        mousePrefab = GameObject.FindGameObjectWithTag("Mouse");
        Time.timeScale = 1;
        globalGameManager = GameObject.FindGameObjectWithTag("GlobalGameManager").GetComponent<GlobalGameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            customerChoose = null;
        }

        if (!canvasPause.activeSelf && !canvasWin.activeSelf && !globalGameManager.OptionCanvas.activeSelf)
        {
            mousePrefab.SetActive(true);
            if (globalGameManager.Scroll)
            {
                cinemachineComposition.SetActive(true);
                cinemachineBrain.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                cinemachineBrain.enabled = false;
                cinemachineComposition.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
            
        }
        else
        {
            mousePrefab.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetButtonDown("Pause"))
        {
            Pause();
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

    public void Pause()
    {
        if (Time.timeScale == 0 && canvasPause.activeSelf)
        {
            canvasPause.SetActive(false);
            Time.timeScale = 1;
        }
        else if (Time.timeScale == 1 && !canvasPause.activeSelf)
        {
            canvasPause.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Options()
    {
        globalGameManager.Options(canvasPause);
    }
}
