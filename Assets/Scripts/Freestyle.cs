using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freestyle : MonoBehaviour {
    public int freestylePrize;
    private bool isActive;
    private float activeTimelimit;
    private float accumulatedTime = 0 ;
    private float activateTime;
    public List<DanceMove> recentMovesP1;
    public List<DanceMove> recentMovesP2;
    private ScoringSystem scoringSystem;
    private InputCheck inputCheck;
    private DanceMove lastMove;
    int repitionScore = 25;
    int maxScore = 100;
    public bool stateFinished = false;
    private int playerOneScore;
    private int playerTwoScore;
    // Use this for initialization
    void Start () {
        
    }
	public void OnStart()
    {
        isActive = true;
        recentMovesP1 = new List<DanceMove>();
        recentMovesP2 = new List<DanceMove>();
        inputCheck = GameObject.FindGameObjectWithTag("GameController").GetComponent<InputCheck>();
        scoringSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoringSystem>();
    }
	// Update is called once per frame
	void Update () {

    }
    public void OnUpdate ()
    {
        Debug.Log(activeTimelimit);
        accumulatedTime += Time.deltaTime;
        if (accumulatedTime < activeTimelimit)
        {

            DanceMove tempMoveP1 = inputCheck.getCurrentMove(true);
            DanceMove tempMoveP2 = inputCheck.getCurrentMove(false);
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

        }
        else 
        {
            stateFinished = true;
            OnStateFinished();
        }
    }

    void OnStateFinished ()
    {
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

    bool CheckIfSameMove (DanceMove move1, DanceMove move2)
    {
        bool temp = false;
        if (move1.LeftArmPosition == move2.LeftArmPosition && move1.RightArmPosition == move2.RightArmPosition && move1.LeftLegPosition == move2.LeftLegPosition && move1.RightLegPosition == move2.RightLegPosition) 
        {
            temp = true;
        }
        return temp;
    }

    public void SetActiveFor (float activeDuration)
    {
        activeTimelimit = activeDuration;
    }
}
