using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freestyle : State {
    public int freestylePrize;
    private bool isActive;
    public float activeTimelimit;
    private float accumulatedTime = 0 ;
    private float measureTimer = 0;
    public float activateTime;
    public List<TempMove> recentMovesP1;
    public List<TempMove> recentMovesP2;
    private GameObject freestyleText;
    private ScoringSystem scoringSystem;
    private InputCheck inputCheck;
    private TempMove lastMove;
    int repitionScore = 25;
    int maxScore = 100;
    public bool stateFinished = false;
    private int playerOneScore;
    private int playerTwoScore;

    private void Start() {
        freestyleText = GameObject.Find("FreestyleText");
        freestyleText.SetActive(false);
    }

    public override void OnStart()
    {
        freestyleText.SetActive(true);
        isActive = true;
        recentMovesP1 = new List<TempMove>();
        recentMovesP2 = new List<TempMove>();
        inputCheck = GameObject.FindGameObjectWithTag("GameController").GetComponent<InputCheck>();
        scoringSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoringSystem>();
    }

    public override bool OnUpdate ()
    {
        accumulatedTime += Time.deltaTime;
        measureTimer += Time.deltaTime;
        if (accumulatedTime < activeTimelimit && measureTimer > 0.25) 
        {
            TempMove tempMoveP1 = inputCheck.getCurrentMove(true);
            TempMove tempMoveP2 = inputCheck.getCurrentMove(false);
            if (recentMovesP1.Count >= 5 && !CheckIfSameMove(recentMovesP1[4], tempMoveP1))
            {
                int tempScore = 0;
                for (int i = recentMovesP1.Count - 1; i >= 0; i--)
                {
                    if (CheckIfSameMove(recentMovesP1[i], tempMoveP1))
                    {
                        tempScore = repitionScore;
                        break;
                    }
                    else
                    {
                        if (i == 0)
                        {
                            tempScore = maxScore;
                        }
                    }
                }
                playerOneScore += tempScore;
                recentMovesP1.Add(tempMoveP1);
                
            }

            if (recentMovesP1.Count < 5) recentMovesP1.Add(tempMoveP1);


            if (recentMovesP2.Count >= 5 && !CheckIfSameMove(recentMovesP2[4], tempMoveP2))
            {
                int tempScore = 0;
                for (int i = recentMovesP2.Count - 1; i >= 0; i--)
                {
                    if (CheckIfSameMove(recentMovesP2[i], tempMoveP2))
                    {
                        tempScore = repitionScore;
                        break;
                    }
                    else 
                    {
                        if (i == 0)
                        {
                            tempScore = maxScore;
                        }
                    }
                    playerOneScore += tempScore;
                    recentMovesP1.Add(tempMoveP1);
                }
            }

            if (recentMovesP2.Count < 5) recentMovesP2.Add(tempMoveP2);

            if (recentMovesP1.Count > 5) recentMovesP1.RemoveAt(0);
            if (recentMovesP2.Count > 5) recentMovesP2.RemoveAt(0);
            measureTimer = 0;
        }
        else if (accumulatedTime >= activeTimelimit)
        {
            stateFinished = true;
            return false;
        }
        return true;
    }

    public override void OnEnd ()
    {
        if (GetComponent<AudioSource>()) {
            GetComponent <AudioSource>().Play();
        }
        freestyleText.SetActive(false);
        if (playerOneScore > playerTwoScore)
        {
            scoringSystem.AddFirstPlayerScore(freestylePrize, freestylePrize);
        } else if (playerTwoScore > playerOneScore)
        {
            scoringSystem.AddFirstPlayerScore(freestylePrize, freestylePrize);
        } else
        {
            int temp = Random.Range(0, 2);
            if (temp == 0) scoringSystem.AddFirstPlayerScore(freestylePrize, freestylePrize);
            else scoringSystem.AddSecondPlayerScore(freestylePrize, freestylePrize);
        }
        Debug.Log(playerOneScore + " " + playerTwoScore);
    }

    bool CheckIfSameMove (TempMove move1, TempMove move2)
    {
        bool temp = false;
        if (move1.LeftArmPosition == move2.LeftArmPosition && move1.RightArmPosition == move2.RightArmPosition && move1.LeftLegPosition == move2.LeftLegPosition && move1.RightLegPosition == move2.RightLegPosition) 
        {
            temp = true;
        }
        return temp;
    }

}
