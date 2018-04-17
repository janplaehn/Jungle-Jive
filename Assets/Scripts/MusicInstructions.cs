using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicInstructions : MonoBehaviour {
    private Pair<DanceMove, float>[] timingPairs;
    public Sprite voidSprite;
    public Sprite[] instructionImageArray;
    public Image instruction;
    public Image timing;
    //public Image timing;
    public Image nextInstruction;
    private float accumulatedTime = 0f;
    public AudioSource musicSource;
    private ScoringSystem scoringSystem;
    private InputCheck inputCheck;
    private DanceMove lastMove;
    private int lastPairIndex = 0;
    private bool finished = false;
    private bool moveRated = false;

    public float instructionTime;
    private float errorMargin = 0.2f;
    private float scaleTiming = 1;
    public enum DanceMoveEnum
    {
        LeftArmUp,
        RightArmUp,
        BothArmsUp,
        BothArmsDown,
        SplitArmsUp,
        SplitArmsDown,
        LeftArmLeftLegUp,
        RightArmRightLegUp,
    }

	// Use this for initialization
	void Start () {
        lastMove = timingPairs[0].firstValue;
        nextInstruction.sprite = instructionImageArray[lastMove.instructionImageIndex];
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



            if (accumulatedTime <= instructionTime)
            {
                animateTiming(instructionTime/2, accumulatedTime);
                if (inputCheck.CheckLimbs(lastMove) == 1 && moveRated == false)
                {
                    if (accumulatedTime > timingPairs[lastPairIndex].secondValue - errorMargin && accumulatedTime < timingPairs[lastPairIndex].secondValue + errorMargin)
                    {
                        scoringSystem.AddFirstPlayerScore(inputCheck.CheckScore(lastMove, 2), inputCheck.GetMaxScore(lastMove));
                        
                    } else
                    {
                        scoringSystem.AddFirstPlayerScore(inputCheck.CheckScore(lastMove, 1), inputCheck.GetMaxScore(lastMove));
                    }
                    moveRated = true;
                    timing.sprite = voidSprite;
                }
                
            } else
            {

                if (moveRated == false) scoringSystem.AddFirstPlayerScore(inputCheck.CheckScore(lastMove, 1), inputCheck.GetMaxScore(lastMove));
                lastPairIndex++;
                if (timingPairs.Length <= lastPairIndex)
                {
                    finished = true;
                    instruction.sprite = voidSprite;
                    nextInstruction.sprite = voidSprite;
                    lastPairIndex = 0;
                    accumulatedTime = 0f;
                    GetComponent<GameControlling>().GameOver();
                    return;
                }

                moveRated = false;
                accumulatedTime = 0f;
                
                instruction.sprite = instructionImageArray[timingPairs[lastPairIndex].firstValue.instructionImageIndex];
                timing.sprite = instructionImageArray[timingPairs[lastPairIndex].firstValue.instructionImageIndex];
                timing.rectTransform.localScale = new Vector3(scaleTiming, scaleTiming, 1);
                if (lastPairIndex + 1 <= timingPairs.Length - 1)
                {
                    nextInstruction.sprite = instructionImageArray[timingPairs[lastPairIndex + 1].firstValue.instructionImageIndex];
                }
                else
                {
                    nextInstruction.sprite = voidSprite;
                }
                lastMove = timingPairs[lastPairIndex].firstValue;
            }





            /*if(accumulatedTime >= timingPairs[lastPairIndex].secondValue)
            {
                //Invoke("ClearInstructionImage", 1f);
                //ClearInstructionImage();
                Debug.Log(timingPairs[lastPairIndex].firstValue);
                instruction.sprite = instructionImageArray[ timingPairs[lastPairIndex].firstValue.instructionImageIndex ];
                if(lastPairIndex + 1 < timingPairs.Length - 1)
                {
                    nextInstruction.sprite = instructionImageArray[timingPairs[lastPairIndex + 1].firstValue.instructionImageIndex];
                } else
                {
                    nextInstruction.sprite = voidSprite;
                }
                lastMove = timingPairs[lastPairIndex].firstValue;
                lastPairIndex++;
                if(timingPairs.Length <= lastPairIndex)
                {
                    finished = true;
                    instruction.sprite = voidSprite;
                    nextInstruction.sprite = voidSprite;
                    lastPairIndex = 0;
                    accumulatedTime = 0f;
                }
            }*/
        }
	}

    public void SetMusic(AudioClip givenMusic, Pair<DanceMove, float>[] givenPairs)
    {
        musicSource.clip = givenMusic;
        musicSource.Play();
        timingPairs = givenPairs;
        finished = false;
    }

    void animateTiming (float perfectTime, float accumulatedTime)
    {
        timing.rectTransform.localScale = new Vector3(1 + (2 * (perfectTime - accumulatedTime)) / perfectTime, 1 + (2 * (perfectTime - accumulatedTime)) / perfectTime, 0);
        if ((1 + (2 * (perfectTime - accumulatedTime)) / perfectTime) <= 1) {
            timing.sprite = voidSprite;
        }

    }
}