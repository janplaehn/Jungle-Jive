using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManagement : MonoBehaviour {

    public AudioMixerGroup mixerGroup;

    public MusicTrack[] tracks;

    [HideInInspector] public static MusicManagement instance = null;

    private bool isFirstInstance = false;

    private void Awake() {
        if (instance == null) {
            instance = this;
            isFirstInstance = true;
        }
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(this.gameObject);

        foreach (MusicTrack t in tracks) {
            t.source = gameObject.AddComponent<AudioSource>();
            t.source.clip = t.clip;
            t.source.loop = t.loop;

            t.source.outputAudioMixerGroup = mixerGroup;
        }
    }

    public void Play(string sound) {
        MusicTrack s = Array.Find(tracks, item => item.name == sound);
        if (s == null) {
            Debug.LogWarning("Track: " + name + " not found!");
            return;
        }

        s.source.volume = s.volume;
        s.source.pitch = s.pitch;
        s.source.Play();
    }

    public void Stop(string sound) {
        MusicTrack s = Array.Find(tracks, item => item.name == sound);
        if (s == null) {
            Debug.LogWarning("Track: " + name + " not found!");
            return;
        }

        s.source.Stop();
    }

    public void SetVolume(string sound, float Volume) {
        MusicTrack s = Array.Find(tracks, item => item.name == sound);
        if (s == null) {
            Debug.LogWarning("Track: " + name + " not found!");
            return;
        }

        s.source.volume = Volume;
    }

    public void SetPitch(string sound, float Pitch) {
        MusicTrack s = Array.Find(tracks, item => item.name == sound);
        if (s == null) {
            Debug.LogWarning("Track: " + name + " not found!");
            return;
        }

        s.source.pitch = Pitch;
    }
}
