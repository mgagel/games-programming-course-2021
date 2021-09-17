using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SoundVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("SoundVolume", 0.75f);
    }

    public void SetLevel()
    {
        float sliderValue = slider.value;
        mixer.SetFloat("SoundVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SoundVolume", sliderValue);
    }
}
