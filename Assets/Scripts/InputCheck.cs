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
        GetLimbs(Players.PlayerOne);
        GetLimbs(Players.PlayerTwo);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (leftArm == null)
        {
            GetLimbs(Players.PlayerOne);
        }
        if (leftArmP2 == null)
        {
            GetLimbs(Players.PlayerTwo);
        }
    }

    void GetLimbs(Players player)
    {
        if(player == Players.PlayerOne)
        {
            leftArm = GetLimb("LeftArm");
            rightArm = GetLimb("RightArm");
            leftLeg = GetLimb("LeftLeg");
            rightLeg = GetLimb("RightLeg");
        } else
        {
            leftArmP2 = GetLimb("LeftArmP2");
            rightArmP2 = GetLimb("RightArmP2");
            leftLegP2 = GetLimb("LeftLegP2");
            rightLegP2 = GetLimb("RightLegP2");
        }
    }

    LimbMovement GetLimb(string givenTag)
    {
        GameObject t = GameObject.FindGameObjectWithTag(givenTag);
        if (t) return t.GetComponent<LimbMovement>();
        return null;
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
        }
        else if (player == Players.PlayerTwo)
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

    public DanceMove getCurrentMove (bool isPlayerOne) //Gets current position of limbs as DanceMove from player one or two
    {
        DanceMove temp = new DanceMove(1, 1, 1, 1, 1);
        if (isPlayerOne == true)
        {
            temp.LeftArmPosition = leftArm.GetLimbState();
            temp.RightArmPosition = rightArm.GetLimbState();
            temp.LeftLegPosition = leftLeg.GetLimbState();
            temp.RightLegPosition = rightLeg.GetLimbState();
        } else
        {
            temp.LeftArmPosition = leftArmP2.GetLimbState();
            temp.RightArmPosition = rightArmP2.GetLimbState();
            temp.LeftLegPosition = leftLegP2.GetLimbState();
            temp.RightLegPosition = rightLegP2.GetLimbState();
        }
        return temp;
    }

    public float GetShakingUp(Players player)
    {
        float r = 0f;
        if(player == Players.PlayerOne)
        {
            r += GetShakingUp(leftArm);
            r += GetShakingUp(rightArm);
        } else
        {
            r += GetShakingUp(leftArmP2);
            r += GetShakingUp(rightArmP2);
        }
        return r;
    }

    private float GetShakingUp(LimbMovement limb)
    {
        if (limb.GetLimbState() == 2)
            return Mathf.Abs(limb.lastRotation - limb.transform.rotation.eulerAngles.z);
        return 0f;
    }
}
