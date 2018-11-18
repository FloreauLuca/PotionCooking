using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class LoopRandomSound : MonoBehaviour {

    [SerializeField]
    private AudioClip[] audioClipArray;
    [SerializeField]
    private float distanceSoundMinimum = 10;
    [SerializeField]
    private float distanceSoundMaximum = 2;

    [SerializeField]
    private float byPassLowDefault = 15340.00f;
    [SerializeField]
    private float byPassLowffect = 1718.00f;
    [SerializeField]
    private LayerMask soundObjectMask;
    [SerializeField]
    private AudioMixer audioMixer;

    private AudioSource audioSource;
    private Transform playerTransform;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        audioMixer.SetFloat("DuckLowPassEffect", byPassLowDefault);
    }
	
	// Update is called once per frame
	void Update () {

        SoundRaycastEffect();

        float distancePlayer = Vector2.Distance(playerTransform.position, transform.position);
        distancePlayer -= distanceSoundMaximum;
        float soundRange = distanceSoundMinimum - distanceSoundMaximum;
        float volume = distancePlayer / soundRange;
        if(volume >= soundRange)
        {
            volume = 1;
        }
        volume = 1 - volume;
        audioSource.volume = volume;

        if (!audioSource.isPlaying)
        {
            int indexRandom = Random.Range(0, audioClipArray.Length);
            audioSource.clip = audioClipArray[indexRandom];
            audioSource.Play();
        }

		
	}

    private void SoundRaycastEffect()
    {
        Vector2 direction = playerTransform.position - transform.position;

       RaycastHit2D hit =   Physics2D.Raycast(transform.position, direction, 200, soundObjectMask);
        if (hit)
        {
            audioMixer.SetFloat("DuckLowPassEffect", byPassLowffect);
            Debug.Log("Low");
        }else
        {
            audioMixer.SetFloat("DuckLowPassEffect", byPassLowDefault);
            Debug.Log("HIhihi");
        }


    }
}
