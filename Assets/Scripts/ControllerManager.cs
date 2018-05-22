using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControllerManager : MonoBehaviour {
    public static string player1LeftArm;
    public static string player1RightArm;
    public static string player1LeftLeg;
    public static string player1RightLeg;
    public static string player2LeftArm;
    public static string player2RightArm;
    public static string player2LeftLeg;
    public static string player2RightLeg;
    public float invokeTimer;
    public Text instructionText;
    private int checkedIndex = 0;

    enum LimbType
    {
        p1LeftArm = 0,
        p1RightArm = 1,
        p1LeftLeg = 2,
        p1RightLeg = 3,
        p2LeftArm = 4,
        p2RightArm = 5,
        p2LeftLeg = 6,
        p2RightLeg = 7
    }

	// Use this for initialization
	void Start () {
        if (!instructionText) Debug.LogError("Forgot to assign Instruction Text");
        Invoke("CheckLimbs", invokeTimer);
	}
	
	private void CheckLimbs()
    {
        bool hasChecked = false;
        switch (checkedIndex)
        {
            case (int)LimbType.p1LeftArm:
                if ((player1LeftArm = GetLimb(false)) != "") hasChecked = true;
                break;
            case (int)LimbType.p1RightArm:
                if ((player1RightArm = GetLimb(false)) != "") hasChecked = true;
                break;
            case (int)LimbType.p1LeftLeg:
                if ((player1LeftLeg = GetLimb(true)) != "") hasChecked = true;
                break;
            case (int)LimbType.p1RightLeg:
                if ((player1RightLeg = GetLimb(true)) != "") hasChecked = true;
                break;
            case (int)LimbType.p2LeftArm:
                if ((player2LeftArm = GetLimb(false)) != "") hasChecked = true;
                break;
            case (int)LimbType.p2RightArm:
                if ((player2RightArm = GetLimb(false)) != "") hasChecked = true;
                break;
            case (int)LimbType.p2LeftLeg:
                if ((player2LeftLeg = GetLimb(true)) != "") hasChecked = true;
                break;
            case (int)LimbType.p2RightLeg:
                if ((player2RightLeg = GetLimb(true)) != "") hasChecked = true;
                break;
            default:
                Debug.LogError("O fugg, something went really wrong");
                break;
        }
        if (hasChecked)
        {
            checkedIndex++;
            DisplayInstructions(checkedIndex);
        }
        if (checkedIndex < 8) Invoke("CheckLimbs", invokeTimer);
    }

    private void DisplayInstructions(int index)
    {
        switch (checkedIndex)
        {
            case (int)LimbType.p1LeftArm:
                instructionText.text = "Raise player one's left arm!"; break;
            case (int)LimbType.p1RightArm:
                instructionText.text = "Raise player one's right arm!"; break;
            case (int)LimbType.p1LeftLeg:
                instructionText.text = "Raise player one's left leg!"; break;
            case (int)LimbType.p1RightLeg:
                instructionText.text = "Raise player one's right leg!"; break;
            case (int)LimbType.p2LeftArm:
                instructionText.text = "Raise player two's left arm!"; break;
            case (int)LimbType.p2RightArm:
                instructionText.text = "Raise player two's right arm!"; break;
            case (int)LimbType.p2LeftLeg:
                instructionText.text = "Raise player two's left leg!"; break;
            case (int)LimbType.p2RightLeg:
                instructionText.text = "Raise player two's right leg!"; break;
            default:
                instructionText.text = ""; break;
        }
    }

    private string GetLimb(bool isLeg)
    {
        
        float threshold = 0.5f;
        if (isLeg) threshold -= 0.3f;
        if(CheckAxis("LeftStickVertical", threshold)){
            if(ConfirmAxis("LeftStickVertical") != "") return "LeftStickVertical";
        }
        if (CheckAxis("RightStickVertical", threshold))
        {
            if (ConfirmAxis("RightStickVertical") != "") return "RightStickVertical";
        }
        if (CheckAxis("LeftStickHorizontal", threshold))
        {
            if (ConfirmAxis("LeftStickHorizontal") != "") return "LeftStickHorizontal";
        }
        if (CheckAxis("RightStickHorizontal", threshold))
        {
            if (ConfirmAxis("RightStickHorizontal") != "") return "RightStickHorizontal";
        }


        if (CheckAxis("P2LeftStickVertical", threshold))
        {
            if (ConfirmAxis("P2LeftStickVertical") != "") return "P2LeftStickVertical";
        }
        if (CheckAxis("P2RightStickVertical", threshold))
        {
            if (ConfirmAxis("P2RightStickVertical") != "") return "P2RightStickVertical";
        }
        if (CheckAxis("P2LeftStickHorizontal", threshold))
        {
            if (ConfirmAxis("P2LeftStickHorizontal") != "") return "P2LeftStickHorizontal";
        }
        if (CheckAxis("P2RightStickHorizontal", threshold))
        {
            if (ConfirmAxis("P2RightStickHorizontal") != "") return "P2RightStickHorizontal";
        }
        return "";
    }

    private bool CheckAxis(string limb, float threshold)
    {
        if (Input.GetAxis(limb) > threshold || Input.GetAxis(limb) < -threshold)
        {
            return true;
        }
        return false;
    }

    private string ConfirmAxis(string axis)
    {
        if(axis == player1LeftArm 
            || axis == player1RightArm 
            || axis == player1LeftLeg 
            || axis == player1RightLeg
            || axis == player2LeftArm
            || axis == player2RightArm
            || axis == player2LeftLeg
            || axis == player2RightLeg)
        {
            return "";
        } else
        {
            return axis;
        }
        
    }                  
}