using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class GlobalGameManager : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;
    private float volumeMusic = 0.5f;
    public float VolumeMusic
    {
        get { return volumeMusic; }
        set
        {
            volumeMusic = value;
            audioMixer.SetFloat("musicVolume", Mathf.Log(VolumeMusic) * 20);
        }
    }
    private float volumeSound = 0.5f;
    public float VolumeSound
    {
        get { return volumeSound; }
        set
        {
            volumeSound = value;
            audioMixer.SetFloat("dropObjectSoundVolume", Mathf.Log(VolumeSound) * 20);
        }
    }
    private float volumeMaster = 0.5f;
    public float VolumeMaster
    {
        get { return volumeMaster; }
        set
        {
            volumeMaster = value;
            audioMixer.SetFloat("masterVolume", Mathf.Log(VolumeMaster) * 20);
        }
    }


    [SerializeField] private GameObject optionCanvas;
    private GameObject canvasBeforeOptions = null;
    [SerializeField] private GameObject scrollPanel;

    /*                     Utilisable dans les futurs versions
    private bool scroll; 
    public bool Scroll
    {
        get { return scroll; }
        set { scroll = value; }
    }
    private float sensitivity;
    public float Sensitivity
    {
        get { return sensitivity; }
        set { sensitivity = value; }
    }
    
    public void ScrollUpdate()
    {
        scrollPanel.SetActive(Scroll);
    }*/

    private static GlobalGameManager instance;

    void Start()
    {
        if (instance == null) // empeche l'existance de plusieurs GlobalGameManager
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        ApplyOptions();
    }
	
	void Update () {
	    if (Input.GetButtonDown("Cancel"))
	    {
	        Quit();
	    }
    }


    public void Quit()
    {
        Application.Quit();
        //EditorApplication.isPlaying = false;
    }

    void ApplyOptions()
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log(VolumeMusic) * 20);
        audioMixer.SetFloat("masterVolume", Mathf.Log(VolumeMaster) * 20);
        audioMixer.SetFloat("dropObjectSoundVolume", Mathf.Log(VolumeSound) * 20);
    }

    public void Options(GameObject currentCanvas)
    {
        optionCanvas.SetActive(true);
        currentCanvas.SetActive(false);
        canvasBeforeOptions = currentCanvas;
    }

    public void OptionsButton()
    {
        optionCanvas.SetActive(false);
        canvasBeforeOptions.SetActive(true);
        canvasBeforeOptions = null;
        ApplyOptions();
    }

}
