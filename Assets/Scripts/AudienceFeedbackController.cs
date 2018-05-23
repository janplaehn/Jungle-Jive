using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudienceFeedbackController : MonoBehaviour {

    public AudioClip[] sadClip;
    public AudioClip[] okClip;
    public AudioClip[] wowClip;
    private AudioSource audio;
    float initialPitch;
    public Sprite[] sad;
    public Sprite[] neutral;
    public Sprite[] happy;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        initialPitch = audio.pitch;
    }

    public void GiveFaceFeedback(int score, int maxScore) {
        float percentage = ((float)(score) / (float)(maxScore)) * 100f;
        if (percentage == 0f || (percentage < 25f && percentage != 0f)) {
            PlayClip(sadClip);
            SetSprite(sad);
        }
        else if (percentage >= 25f && percentage < 50f) {
            PlayClip(okClip);
            SetSprite(neutral);
        }
        else if ((percentage >= 50f && percentage < 75f) || percentage >= 75f) {
            PlayClip(wowClip);
            SetSprite(happy);
        }
        else {
            SetSprite(neutral);
            Debug.LogWarning("Invalid score format " + percentage + " detected. Unable to display face feedback Sprite.");
        }

    }

    public void PlayClip(AudioClip[] c)
    {
        int index = Random.Range(0, c.Length);
        audio.Stop();
        audio.clip = c[index];
        audio.pitch = Random.Range(initialPitch - 0.2f, initialPitch + 0.21f);
        audio.Play();
    }

    public void BeHappy() {
        SetSprite(happy);
    }

    void SetSprite(Sprite[] spriteArray) {
        int spriteNumber = Random.Range(0, spriteArray.Length);
        GetComponent<SpriteRenderer>().sprite = spriteArray[spriteNumber];
    }
}