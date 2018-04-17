using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCheck : MonoBehaviour {
    LimbMovement leftArm;
    LimbMovement rightArm;
    LimbMovement leftLeg;
    LimbMovement rightLeg;

	// Use this for initialization
	void Start () {
        leftArm = GameObject.FindGameObjectWithTag("LeftArm").GetComponent<LimbMovement>();
        rightArm = GameObject.FindGameObjectWithTag("RightArm").GetComponent<LimbMovement>();
        leftLeg = GameObject.FindGameObjectWithTag("LeftLeg").GetComponent<LimbMovement>();
        rightLeg = GameObject.FindGameObjectWithTag("RightLeg").GetComponent<LimbMovement>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public int CheckScore(DanceMove currentMove)
    {
        return (int) (100 * CheckLimbs(currentMove));
    }

    float CheckLimbs(DanceMove currentMove)
    {
        float index = 0f;
        float score = 0f;
        if (currentMove.LeftArmPosition != -1)
        {
            index++;
            if (leftArm.GetLimbState() == currentMove.LeftArmPosition) score ++;
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
        return score / index;
    }
}
