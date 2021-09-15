using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseOptionsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer musicMixer;
    [SerializeField] private AudioMixer SFXMixer; 

    public void SetMusicVolume(float volume)
    {
        //Debug.Log(volume);
        musicMixer.SetFloat("volume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        SFXMixer.SetFloat("SFXVolume", volume);
    }
}
