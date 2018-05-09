using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class MusicTrack {

    public string name;
    public AudioClip clip;
    [Range(0f, 1f)] public float volume;
    [Range(0f, 2f)] public float pitch = 1;
    public bool loop = true;
    [HideInInspector]  public AudioMixerGroup mixerGroup;
    [HideInInspector]  public AudioSource source;
}
