using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject globalGameManager;

    [SerializeField] private GameObject optionsCanvas;
    [SerializeField] private GameObject mainMenuCanvas;

    [SerializeField] private GameObject creditCanvas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void OptionsButton()
    {
        optionsCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }

    public void CreditButton()
    {
        creditCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void BackButton()
    {
        optionsCanvas.SetActive(false);
        creditCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }
}
