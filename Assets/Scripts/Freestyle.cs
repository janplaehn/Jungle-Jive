using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freestyle : MonoBehaviour {
    private bool isActive;
    private float activeTimelimit;
    private float accumulatedTime;
    public List<DanceMove> recentMoves;
    [SerializeField] private bool isPlayerOne;
    private ScoringSystem scoringSystem;
    private InputCheck inputCheck;
    private DanceMove lastMove;
    int repitionScore = 25;
    int maxScore = 100;
    // Use this for initialization
    void Start () {
        isActive = false;
        recentMoves = new List<DanceMove>();
        inputCheck = GameObject.FindGameObjectWithTag("GameController").GetComponent<InputCheck>();
        scoringSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoringSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isActive == true)
        {
            accumulatedTime += Time.deltaTime;
            if (accumulatedTime < activeTimelimit)
            {
                DanceMove tempMove = inputCheck.getCurrentMove(isPlayerOne);
                if (recentMoves.Count >= 5)
                {
                    if (isPlayerOne == true)
                    {
                        scoringSystem.AddFirstPlayerScore(GetScore(tempMove), maxScore);  //Let scoring run through a different function so it doesn't trigger feedback text?
                    } else
                    {
                        scoringSystem.AddSecondPlayerScore(GetScore(tempMove), maxScore);
                    }
                    

                }
                else
                {
                    recentMoves.Add(tempMove);
                }
                if (recentMoves.Count > 5) recentMoves.RemoveAt(0);
            } else
            {
                isActive = false;
            }
            
        }
    }

    int GetScore (DanceMove currentMove)
    {
        int tempScore = 0;
        for (int i = recentMoves.Count; i >= 0; i--)
        {
            if (CheckIfSameMove(currentMove, recentMoves[5])) break;
            else if (CheckIfSameMove(currentMove, recentMoves[i]))
            {
                if (isPlayerOne == true)
                {
                    tempScore = repitionScore;
                }
                else
                {
                    tempScore = repitionScore;
                }
                break;
            }
        }
        if (tempScore != repitionScore) tempScore = maxScore;
        return tempScore;
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

    public void SetActiveFor (float activeTime)
    {
        isActive = true;
        activeTimelimit = activeTime;
    }
}
