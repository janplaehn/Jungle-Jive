using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicInstructions : State {
    [SerializeField]public DanceMovePair[] timingPairs;
    public Sprite voidSprite;
    public Sprite[] instructionImageArray;
    public Image instruction;
    public Image timing;
    public Image nextInstruction;
    private float accumulatedTime = 0f;
    public AudioSource musicSource;
    private ScoringSystem scoringSystem;
    private InputCheck inputCheck;
    private DanceMove lastMove;
    private int lastPairIndex = 0;
    private bool started = true;
    public bool stateFinished = false;
    private bool moveRatedP1 = false;
    private bool moveRatedP2 = false;
    private bool intro = true;
    public float introTime;
    public float tempo;
    public Sprite timingSprite;
    [Range(1f, 4f)] public float maxTimingSpriteSize = 1.5f;

    private float errorMargin = 0.2f;
    public bool isPaused = false;
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
        LeftArmleftLegAside,
        RightArmrightLegAside,
        LeftArmRightLegSlash,
        rightArmLeftLegSlash
    }

	// Use this for initialization
	public override void OnStart () {
        lastMove = timingPairs[lastPairIndex].firstValue;
        nextInstruction.sprite = instructionImageArray[(int)lastMove.instructionImageIndex];
        inputCheck = GameObject.FindGameObjectWithTag("GameController").GetComponent<InputCheck>();
        scoringSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoringSystem>();
        if (timingPairs.Length == 0)
        {
            started = false;
        }
        instruction.sprite = instructionImageArray[(int)timingPairs[lastPairIndex].firstValue.instructionImageIndex];
        timing.sprite = timingSprite;
        timing.rectTransform.localScale = new Vector3(scaleTiming, scaleTiming, 1);
        if (lastPairIndex + 1 <= timingPairs.Length - 1)
        {
            nextInstruction.sprite = instructionImageArray[(int)timingPairs[lastPairIndex + 1].firstValue.instructionImageIndex];
        }
        else
        {
            nextInstruction.sprite = voidSprite;
        }

        musicSource.Play();
    }

    public override bool OnUpdate ()
    {
        if (started == true && isPaused == false)
        {
            timing.enabled = true;
            accumulatedTime += Time.deltaTime;
            if (accumulatedTime <= GetTiming())
            {
                animateTiming(GetTiming(), accumulatedTime);
                checkTiming(accumulatedTime);
            }
            else
            {
                if (moveRatedP1 == false) scoringSystem.AddFirstPlayerScore(inputCheck.CheckScore(lastMove, 1, InputCheck.Players.PlayerOne), inputCheck.GetMaxScore(lastMove));
                if (moveRatedP2 == false) scoringSystem.AddSecondPlayerScore(inputCheck.CheckScore(lastMove, 1, InputCheck.Players.PlayerTwo), inputCheck.GetMaxScore(lastMove));
                lastPairIndex++;
                if (timingPairs.Length <= lastPairIndex)
                {
                    started = false;
                    stateFinished = true;
                    instruction.sprite = voidSprite;
                    nextInstruction.sprite = voidSprite;
                    lastPairIndex = 0;
                    accumulatedTime = 0f;
                    
                    return false;
                }

                moveRatedP1 = false;
                moveRatedP2 = false;
                accumulatedTime = 0f;
                instruction.sprite = instructionImageArray[(int)timingPairs[lastPairIndex].firstValue.instructionImageIndex];
                timing.sprite = timingSprite;
                timing.rectTransform.localScale = new Vector3(scaleTiming, scaleTiming, 1);
                if (lastPairIndex + 1 <= timingPairs.Length - 1)
                {
                    nextInstruction.sprite = instructionImageArray[(int)timingPairs[lastPairIndex + 1].firstValue.instructionImageIndex];
                }
                else
                {
                    nextInstruction.sprite = voidSprite;
                }
                lastMove = timingPairs[lastPairIndex].firstValue;
            }
        }
        else if (intro == true)
        {
            accumulatedTime += Time.deltaTime;
            if (accumulatedTime >= introTime)
            {
                timing.enabled = true;
                started = true;
                intro = false;
                accumulatedTime = 0f;
            }
        }

        return true;
    }

    public override void OnEnd()
    {
        musicSource.Stop();
    }

    public void SetMusic(AudioClip givenMusic, DanceMovePair[] givenPairs)
    {
        musicSource.clip = givenMusic;
        musicSource.Play();
        timingPairs = givenPairs;
        started = true;
    }

    void animateTiming (float perfectTime, float accumulatedTime)
    {
        timing.rectTransform.localScale = new Vector3(1 + (maxTimingSpriteSize * (perfectTime - accumulatedTime)) / perfectTime, 1 + (maxTimingSpriteSize * (perfectTime - accumulatedTime)) / perfectTime, 0);
        if ((1 + (2 * (perfectTime - accumulatedTime)) / perfectTime) <= 1) {
            timing.sprite = voidSprite;
        }
    }

    void checkTiming (float accTime)
    {
        if (inputCheck.CheckLimbs(lastMove, InputCheck.Players.PlayerOne) == 1 && moveRatedP1 == false)
        {
            if (accTime > GetTiming() - errorMargin && accTime < GetTiming() + errorMargin)
            {
                scoringSystem.AddFirstPlayerScore(inputCheck.CheckScore(lastMove, 2, InputCheck.Players.PlayerOne), inputCheck.GetMaxScore(lastMove));

            }
            else
            {
                scoringSystem.AddFirstPlayerScore(inputCheck.CheckScore(lastMove, 1, InputCheck.Players.PlayerOne), inputCheck.GetMaxScore(lastMove));
            }
            moveRatedP1 = true;
        }
        if (inputCheck.CheckLimbs(lastMove, InputCheck.Players.PlayerTwo) == 1 && moveRatedP2 == false)
        {
            if (accTime > GetTiming() - errorMargin && accTime < GetTiming() + errorMargin)
            {
                scoringSystem.AddSecondPlayerScore(inputCheck.CheckScore(lastMove, 2, InputCheck.Players.PlayerTwo), inputCheck.GetMaxScore(lastMove));

            }
            else
            {
                scoringSystem.AddSecondPlayerScore(inputCheck.CheckScore(lastMove, 1, InputCheck.Players.PlayerTwo), inputCheck.GetMaxScore(lastMove));
            }
            moveRatedP2 = true;
        }
        if (accTime >= GetTiming()) timing.sprite = voidSprite;
    }

    float GetTiming()
    {
        return timingPairs[lastPairIndex].secondValue * tempo;
    }
}