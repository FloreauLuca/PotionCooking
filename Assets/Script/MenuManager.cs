﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvas;

    [SerializeField] private GameObject creditCanvas;

    private GlobalGameManager globalGameManager;

    void Start()
    {
        Time.timeScale = 1;
        globalGameManager = GameObject.FindGameObjectWithTag("GlobalGameManager").GetComponent<GlobalGameManager>();
    }

    public void OptionsButton()
    {
        globalGameManager.Options(mainMenuCanvas);
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
        creditCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void QuitButton()
    {
        globalGameManager.Quit();
    }
}
