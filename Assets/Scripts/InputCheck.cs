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
        //GetLimbs(Players.PlayerOne);
        //GetLimbs(Players.PlayerTwo);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameObject.FindGameObjectWithTag("Player1"))
        {
            if (leftArm == null)
            {
                GetLimbs(Players.PlayerOne);
            }
        } else
        {
            Debug.Log("player1 not found ");
        }
        if (GameObject.FindGameObjectWithTag("Player2"))
        {
            if (leftArmP2 == null)
            {
                GetLimbs(Players.PlayerTwo);
            }
        } else
        {
            Debug.Log("player1 not found ");

        }
    }

    void GetLimbs(Players player)
    {
        if(player == Players.PlayerOne)
        {
            leftArm = GetLimb("upperArm_lP1");
            rightArm = GetLimb("upperArm_rP1");
            leftLeg = GetLimb("upperLeg_lP1");
            rightLeg = GetLimb("upperLeg_rP1");
        } else
        {
            leftArmP2 = GetLimb("upperArm_lP2");
            rightArmP2 = GetLimb("upperArm_rP2");
            leftLegP2 = GetLimb("upperLeg_lP2");
            rightLegP2 = GetLimb("upperLeg_rP2");
        }
    }

    LimbMovement GetLimb(string givenName)
    {
        GameObject t = GameObject.Find(givenName);
        if (t != null) return t.GetComponent<LimbMovement>();
        Debug.LogWarning(t + " " + givenName);
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
<<<<<<< HEAD
            if (currentMove.LeftArmPosition != -1)
=======
            if (leftArm == null) return 0;
            if ((int)currentMove.LeftArmPosition != -1)
>>>>>>> AlphaBuildIguess
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
<<<<<<< HEAD
            if (currentMove.LeftArmPosition != -1)
=======
            if (leftArmP2 == null) return 0;
            if ((int)currentMove.LeftArmPosition != -1)
>>>>>>> AlphaBuildIguess
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
}