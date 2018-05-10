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

    float[] currentAccel1;
    float[] lastAccel1;

    float[] currentAccel2;
    float[] lastAccel2;

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
        GameObject t = GameObject.FindGameObjectsWithTag(givenTag)[0];
        if (t) return t.GetComponent<LimbMovement>();
        Debug.LogWarning(t + " " + givenTag);
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
            if (leftArm == null) return 0;
            if ((int)currentMove.LeftArmPosition != -1)
            {
                index++;
                if (leftArm.GetLimbState() == (int)currentMove.LeftArmPosition) score++;
            }
            if ((int)currentMove.RightArmPosition != -1)
            {
                index++;
                if (rightArm.GetLimbState() == (int)currentMove.RightArmPosition) score++;
            }
            if ((int)currentMove.LeftLegPosition != -1)
            {
                index++;
                if (leftLeg.GetLimbState() == (int)currentMove.LeftLegPosition) score++;
            }
            if ((int)currentMove.RightLegPosition != -1)
            {
                index++;
                if (rightLeg.GetLimbState() == (int)currentMove.RightLegPosition) score++;
            }
        }
        else if (player == Players.PlayerTwo)
        {
            if (leftArmP2 == null) return 0;
            if ((int)currentMove.LeftArmPosition != -1)
            {
                index++;
                if (leftArmP2.GetLimbState() == (int)currentMove.LeftArmPosition) score++;
            }
            if ((int)currentMove.RightArmPosition != -1)
            {
                index++;
                if (rightArmP2.GetLimbState() == (int)currentMove.RightArmPosition) score++;
            }
            if ((int)currentMove.LeftLegPosition != -1)
            {
                index++;
                if (leftLegP2.GetLimbState() == (int)currentMove.LeftLegPosition) score++;
            }
            if ((int)currentMove.RightLegPosition != -1)
            {
                index++;
                if (rightLegP2.GetLimbState() == (int)currentMove.RightLegPosition) score++;
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
        if ((int)currentMove.LeftArmPosition != -1)
        {
            index++;
            
        }
        if ((int)currentMove.RightArmPosition != -1)
        {
            index++;
            
        }
        if ((int)currentMove.LeftLegPosition != -1)
        {
            index++;
            
        }
        if ((int)currentMove.RightLegPosition != -1)
        {
            index++;
            
        }
        return index;
    }

    public TempMove getCurrentMove (bool isPlayerOne) //Gets current position of limbs as DanceMove from player one or two
    {
        if (leftArm == null)
        {
            GetLimbs(Players.PlayerOne);
            GetLimbs(Players.PlayerTwo);
        }

        TempMove temp = new TempMove();
        if (isPlayerOne == true)
        {
            temp.LeftArmPosition = (TempMove.LimbState)leftArm.GetLimbState();
            temp.RightArmPosition = (TempMove.LimbState)rightArm.GetLimbState();
            temp.LeftLegPosition = (TempMove.LimbState)leftLeg.GetLimbState();
            temp.RightLegPosition = (TempMove.LimbState)rightLeg.GetLimbState();
        } else
        {
            temp.LeftArmPosition = (TempMove.LimbState)leftArmP2.GetLimbState();
            temp.RightArmPosition = (TempMove.LimbState)rightArmP2.GetLimbState();
            temp.LeftLegPosition = (TempMove.LimbState)leftLegP2.GetLimbState();
            temp.RightLegPosition = (TempMove.LimbState)rightLegP2.GetLimbState();
        }
        return temp;
    }

    public float GetShakingUp(Players player)
    {
        float scoreIncrease = 0f;
        if(player == Players.PlayerOne)
        {
            scoreIncrease += GetShakingUp(leftArm);
            scoreIncrease += GetShakingUp(rightArm);
        } else
        {
            scoreIncrease += GetShakingUp(leftArmP2);
            scoreIncrease += GetShakingUp(rightArmP2);
        }
        return scoreIncrease;
    }

    private float GetShakingUp(LimbMovement limb)
    {
        if (limb) {
            if (limb.GetLimbState() == 2) return Mathf.Abs(limb.lastRotation - limb.transform.rotation.eulerAngles.z);
        }
        return 0f;
    }

    public void SetAccel(float[] givenAccel, Players givenPlayer)
    {
        if(givenPlayer == Players.PlayerOne)
        {
            lastAccel1 = currentAccel1;
            currentAccel1 = givenAccel;
        } else
        {
            lastAccel2 = currentAccel2;
            currentAccel2 = givenAccel;
        }
    }

    public void GetAccel()
    {

    }
}