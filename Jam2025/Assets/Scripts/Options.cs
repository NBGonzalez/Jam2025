using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Options : MonoBehaviour
{

    [SerializeField] private Slider ambientSound; 
    [SerializeField] private AudioMixer ambientMixer; 
    [SerializeField] private Slider soundEffect;
    [SerializeField] private AudioMixer effectMixer;
    [SerializeField] private Slider sensibility;

    void Start()
    {
        ambientSound.value = PlayerPrefs.GetFloat("VolumeAmbient");
        ambientMixer.SetFloat("VolumeAmbient", PlayerPrefs.GetFloat("VolumeAmbient"));
        soundEffect.value = PlayerPrefs.GetFloat("VolumeEffect");
        effectMixer.SetFloat("VolumeEffect", PlayerPrefs.GetFloat("VolumeEffect"));
        sensibility.value = PlayerPrefs.GetFloat("Sensibility");
    }

    public void SetAmbientVolume(float volume)
    {
        ambientMixer.SetFloat("VolumeAmbient", volume);
        PlayerPrefs.SetFloat("VolumeAmbient", volume);
    }

    public void SetEffectVolume(float volume)
    {
        effectMixer.SetFloat("VolumeEffect", volume);
        PlayerPrefs.SetFloat("VolumeEffect", volume);
    }

    public void SetSensibility(float value)
    {
        PlayerPrefs.SetFloat("Sensibility", value);
    }



}
