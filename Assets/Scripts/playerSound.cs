using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSound : MonoBehaviour {

    public static AudioSource audioSource;

    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public static void playSound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
