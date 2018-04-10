using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInstructions : MonoBehaviour {
    private Pair<DanceMove, float>[] pairs;
    private float accumulatedTime = 0f;
    public AudioSource musicSource;
    private int lastPairIndex = 0;
    private bool finished = false;
    public enum DanceMove
    {
        LeftArmUp,
        RightArmUp,
        BothArmsUp
    }

	// Use this for initialization
	void Start () {
        if (pairs.Length == 0)
        {
            finished = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(finished == false)
        {
            accumulatedTime += Time.deltaTime;
            if(accumulatedTime >= pairs[lastPairIndex].secondValue)
            {
                Debug.Log(pairs[lastPairIndex].firstValue);
                lastPairIndex++;
                if(pairs.Length <= lastPairIndex)
                {
                    finished = true;
                    lastPairIndex = 0;
                    accumulatedTime = 0f;
                }
            }
        }
	}

    public void SetMusic(AudioClip givenMusic, Pair<DanceMove, float>[] givenPairs)
    {
        musicSource.clip = givenMusic;
        musicSource.Play();
        pairs = givenPairs;
        finished = false;
    }
}
