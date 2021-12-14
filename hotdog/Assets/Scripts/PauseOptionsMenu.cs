using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseOptionsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer musicMixer;
    [SerializeField] private AudioMixer SFXMixer; 
    public MouseLook mouseSensitivity;


    void Awake()
    {
        musicMixer.SetFloat("volume", SettingSaver.musicVolume);
        SFXMixer.SetFloat("SFXVolume", SettingSaver.SFXVolume);
        Camera.main.fieldOfView = SettingSaver.FOVvalue;
        mouseSensitivity.mouseSensitivity = SettingSaver.mouseValue;

    }

    public void SetMusicVolume(float volume)
    {
        //Debug.Log(volume);
        SettingSaver.musicVolume = volume;
        musicMixer.SetFloat("volume", SettingSaver.musicVolume);



        //musicMixer.SetFloat("volume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        SettingSaver.SFXVolume = volume;
        SFXMixer.SetFloat("SFXVolume", SettingSaver.SFXVolume);
    }

    public void SetFOV(float value)
    {
        SettingSaver.FOVvalue = value;
        Camera.main.fieldOfView = SettingSaver.FOVvalue;
    }

    public void SetMouse(float value)
    {   
        SettingSaver.mouseValue = value;
        mouseSensitivity.mouseSensitivity = SettingSaver.mouseValue;
    }
}
