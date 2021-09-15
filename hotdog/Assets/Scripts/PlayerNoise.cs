using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoise : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip[] audioClips;



    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }


    

    void OnCollisionEnter(Collision collision)
    {   

        if(collision.gameObject.tag == "HeadBullet")
        {
            
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
