using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumnManager : MonoBehaviour
{
    public AudioSource audioSrc;
    public GameObject bgVolumeSlider;
    public GameObject effectVolumeSlider; 

	// Use this for initialization
	void Start () {
        audioSrc = GetComponent<AudioSource>();
        bgVolumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("bgVolume", 1f);
        effectVolumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("effectVolume", 1f);
	}
	
	// Update is called once per frame
	void Update () {
        audioSrc.volume = PlayerPrefs.GetFloat("bgVolume", 1f);
	}

    public void SetBGMusicVolume(float vol)
    {
        PlayerPrefs.SetFloat("bgVolume", vol);
    }

    public void SetEffectVolume(float vol)
    {
        PlayerPrefs.SetFloat("effectVolume", vol);
    }
}
