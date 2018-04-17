using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCheck : MonoBehaviour {
    LimbMovement leftArm;
    LimbMovement rightArm;
    LimbMovement leftLeg;
    LimbMovement rightLeg;

    LimbMovement leftArmP2;
    LimbMovement rightArmP2;
    LimbMovement leftLegP2;
    LimbMovement rightLegP2;

    public enum Players
    {
        PlayerOne,
        PlayerTwo,
    }
    // Use this for initialization
    void Start () {
        leftArm = GameObject.FindGameObjectWithTag("LeftArm").GetComponent<LimbMovement>();
        rightArm = GameObject.FindGameObjectWithTag("RightArm").GetComponent<LimbMovement>();
        leftLeg = GameObject.FindGameObjectWithTag("LeftLeg").GetComponent<LimbMovement>();
        rightLeg = GameObject.FindGameObjectWithTag("RightLeg").GetComponent<LimbMovement>();

        leftArmP2 = GameObject.FindGameObjectWithTag("LeftArmP2").GetComponent<LimbMovement>();
        rightArmP2 = GameObject.FindGameObjectWithTag("RightArmP2").GetComponent<LimbMovement>();
        leftLegP2 = GameObject.FindGameObjectWithTag("LeftLegP2").GetComponent<LimbMovement>();
        rightLegP2 = GameObject.FindGameObjectWithTag("RightLegP2").GetComponent<LimbMovement>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public int CheckScore(DanceMove currentMove, int timeMultiplier, Players player)
    {
        return (int) (100 * GetLimbMultiplier(currentMove) * CheckLimbs(currentMove, player) * timeMultiplier);
    }

    public float CheckLimbs(DanceMove currentMove, Players player)
    {
        float index = 0f;
        float score = 0f;
        if (player == Players.PlayerOne)
        {
            if (currentMove.LeftArmPosition != -1)
            {
                index++;
                if (leftArm.GetLimbState() == currentMove.LeftArmPosition) score++;
            }
            if (currentMove.RightArmPosition != -1)
            {
                index++;
                if (rightArm.GetLimbState() == currentMove.RightArmPosition) score++;
            }
            if (currentMove.LeftLegPosition != -1)
            {
                index++;
                if (leftLeg.GetLimbState() == currentMove.LeftLegPosition) score++;
            }
            if (currentMove.RightLegPosition != -1)
            {
                index++;
                if (rightLeg.GetLimbState() == currentMove.RightLegPosition) score++;
            }
        } else if (player == Players.PlayerTwo)
        {
            if (currentMove.LeftArmPosition != -1)
            {
                index++;
                if (leftArmP2.GetLimbState() == currentMove.LeftArmPosition) score++;
            }
            if (currentMove.RightArmPosition != -1)
            {
                index++;
                if (rightArmP2.GetLimbState() == currentMove.RightArmPosition) score++;
            }
            if (currentMove.LeftLegPosition != -1)
            {
                index++;
                if (leftLegP2.GetLimbState() == currentMove.LeftLegPosition) score++;
            }
            if (currentMove.RightLegPosition != -1)
            {
                index++;
                if (rightLegP2.GetLimbState() == currentMove.RightLegPosition) score++;
            }
        }
        
        return score / index;
        
    }
    public int GetMaxScore (DanceMove currentMove)
    {
        return 100 * GetLimbMultiplier(currentMove) * 2; // times two is for when the player times their dance move perfectly
    }
    private int GetLimbMultiplier (DanceMove currentMove)
    {
        int index = 0;
        if (currentMove.LeftArmPosition != -1)
        {
            index++;
            
        }
        if (currentMove.RightArmPosition != -1)
        {
            index++;
            
        }
        if (currentMove.LeftLegPosition != -1)
        {
            index++;
            
        }
        if (currentMove.RightLegPosition != -1)
        {
            index++;
            
        }
        return index;
    }
}
