using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class GlobalGameManager : MonoBehaviour
{
    private int option;
    private bool scroll;
    private float volumeMusic = 1;
    private float volumeSound = 1;
    private float volumeMaster = 1;
    private float sensitivity = 0.25f;
    [SerializeField] private GameObject optionCanvas;
    [SerializeField] private AudioMixer audioMixer;
    private GameObject canvasBeforeOptions = null;
    [SerializeField] private GameObject scrollPanel;

    public GameObject OptionCanvas
    {
        get { return optionCanvas; }
    }

    public bool Scroll
    {
        get { return scroll; }
        set { scroll = value; }
    }

    public float VolumeMusic
    {
        get { return volumeMusic; }
        set { volumeMusic = value; }
    }

    public float VolumeSound
    {
        get { return volumeSound; }
        set { volumeSound = value; }
    }

    public float VolumeMaster
    {
        get { return volumeMaster; }
        set { volumeMaster = value; }
    }

    public float Sensitivity
    {
        get { return sensitivity; }
        set { sensitivity = value; }
    }

    // Use this for initialization
    void Start () {
        foreach (GameObject globalGameManager in GameObject.FindGameObjectsWithTag("GlobalGameManager"))
        {
            if (globalGameManager != gameObject)
                Destroy(gameObject);
        }
		DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
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

    public void ScrollUpdate()
    {
        scrollPanel.SetActive(Scroll);
    }
}
