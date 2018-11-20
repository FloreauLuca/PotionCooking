using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private bool unpaused = true;
    [SerializeField] private GameObject currentCamera = null;

    [SerializeField] private GameObject canvasPause;
    [SerializeField] private GameObject canvasWin;
    [SerializeField] private GameObject scoreText;

    [SerializeField] private GameObject winText;

    private GlobalGameManager globalGameManager;

    public bool Unpaused
    {
        get { return unpaused; }
        set { unpaused = value; }
    }

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        globalGameManager = GameObject.FindGameObjectWithTag("GlobalGameManager").GetComponent<GlobalGameManager>();
    }

    // Update is called once per frame
    void Update()
    {

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
        if (servedCustomer*2 >= totalNumberCustomer)
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
            unpaused = true;
            canvasPause.SetActive(false);
            Time.timeScale = 1;
        }
        else if (Time.timeScale == 1 && !canvasPause.activeSelf)
        {
            unpaused = false;
            canvasPause.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Options()
    {
        globalGameManager.Options(canvasPause);
    }
}
