using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicInstructions : MonoBehaviour {
    private Pair<DanceMove, float>[] timingPairs;
    public Sprite voidSprite;
    public Sprite[] instructionImageArray;
    public Image instruction;
    private float accumulatedTime = 0f;
    public AudioSource musicSource;
    private ScoringSystem scoringSystem;
    private InputCheck inputCheck;
    private DanceMove lastMove;
    private int lastPairIndex = 0;
    private bool finished = false;
    public enum DanceMoveEnum
    {
        LeftArmUp,
        RightArmUp,
        BothArmsUp
    }

	// Use this for initialization
	void Start () {
        lastMove = timingPairs[0].firstValue;
        inputCheck = GetComponent<InputCheck>();
        scoringSystem = GetComponent<ScoringSystem>();
        if (timingPairs.Length == 0)
        {
            finished = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(finished == false)
        {
            accumulatedTime += Time.deltaTime;
            if(accumulatedTime >= timingPairs[lastPairIndex].secondValue)
            {
                Invoke("ClearInstructionImage", 0.5f);
                Debug.Log(timingPairs[lastPairIndex].firstValue);
                instruction.sprite = instructionImageArray[ timingPairs[lastPairIndex].firstValue.instructionImageIndex ];
                lastMove = timingPairs[lastPairIndex].firstValue;
                lastPairIndex++;
                if(timingPairs.Length <= lastPairIndex)
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
        timingPairs = givenPairs;
        finished = false;
    }

    private void ClearInstructionImage()
    {
        instruction.sprite = voidSprite;
        scoringSystem.AddFirstPlayerScore(inputCheck.CheckScore(lastMove));
    }
}