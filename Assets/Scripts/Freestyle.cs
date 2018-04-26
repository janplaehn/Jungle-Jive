using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freestyle : MonoBehaviour {
    private bool isActive;
    private float activeTimelimit = 0;
    private float accumulatedTime = 0;
    private float activateTime = 0;
    public List<DanceMove> recentMovesP1;
    public List<DanceMove> recentMovesP2;
    private ScoringSystem scoringSystem;
    private InputCheck inputCheck;
    private DanceMove lastMove;
    int repitionScore = 25;
    int maxScore = 100;
    public bool stateFinished = false;
    // Use this for initialization
    void Start () {
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
        accumulatedTime += Time.deltaTime;
        if (accumulatedTime > activateTime && activateTime - accumulatedTime < activeTimelimit)
        {

            DanceMove tempMoveP1 = inputCheck.getCurrentMove(true);
            DanceMove tempMoveP2 = inputCheck.getCurrentMove(false);
            if (recentMovesP1.Count >= 5 && !CheckIfSameMove(recentMovesP1[4], tempMoveP1))
            {
                for (int i = recentMovesP1.Count - 1; i >= 0; i--)
                {
                    if (CheckIfSameMove(recentMovesP1[i], tempMoveP1))
                    {
                        scoringSystem.AddFirstPlayerScore(repitionScore, maxScore);
                    }
                    else
                    {
                        scoringSystem.AddFirstPlayerScore(maxScore, maxScore);
                    }
                }
            }
            else if (recentMovesP1.Count < 5)
            {
                recentMovesP1.Add(tempMoveP1);
                scoringSystem.AddFirstPlayerScore(maxScore, maxScore);
            }
            if (recentMovesP2.Count >= 5 && !CheckIfSameMove(recentMovesP2[4], tempMoveP2))
            {
                for (int i = recentMovesP2.Count - 1; i >= 0; i--)
                {
                    if (CheckIfSameMove(recentMovesP2[i], tempMoveP2))
                    {
                        scoringSystem.AddSecondPlayerScore(repitionScore, maxScore);
                    }
                    else
                    {
                        scoringSystem.AddSecondPlayerScore(maxScore, maxScore);
                    }
                }
            }
            else if (recentMovesP2.Count < 5)
            {
                recentMovesP2.Add(tempMoveP2);
                scoringSystem.AddSecondPlayerScore(maxScore, maxScore);
            }
            if (recentMovesP1.Count > 5) recentMovesP1.RemoveAt(0);
            if (recentMovesP2.Count > 5) recentMovesP2.RemoveAt(0);

        }
        else if (accumulatedTime > activateTime && activateTime - accumulatedTime > activeTimelimit)
        {
            stateFinished = true;
        }
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

    public void SetActiveAt (float activeAt, float activeDuration)
    {
        activeTimelimit = activeDuration;
        activateTime = activeAt;
        
    }
}
