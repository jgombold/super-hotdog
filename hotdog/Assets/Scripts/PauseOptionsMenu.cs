using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseOptionsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer musicMixer;
    [SerializeField] private AudioMixer SFXMixer; 
    public MouseLook mouseSensitivity;

    public void SetMusicVolume(float volume)
    {
        //Debug.Log(volume);
        musicMixer.SetFloat("volume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        SFXMixer.SetFloat("SFXVolume", volume);
    }

    public void SetFOV(float value)
    {
        Camera.main.fieldOfView = value;
    }

    public void SetMouse(float value)
    {
        mouseSensitivity.mouseSensitivity = value;
    }
}
