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
        p1LeftArm,
        p1RightArm,
        p1LeftLeg,
        p1RightLeg,
        p2LeftArm,
        p2RightArm,
        p2LeftLeg,
        p2RightLeg
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
                if ((player1LeftArm = GetLimb()) != "") hasChecked = true;
                break;
            case (int)LimbType.p1RightArm:
                if ((player1RightArm = GetLimb()) != "") hasChecked = true;
                break;
            case (int)LimbType.p1LeftLeg:
                if ((player1LeftLeg = GetLimb()) != "") hasChecked = true;
                break;
            case (int)LimbType.p1RightLeg:
                if ((player1RightLeg = GetLimb()) != "") hasChecked = true;
                break;
            case (int)LimbType.p2LeftArm:
                if ((player2LeftArm = GetLimb()) != "") hasChecked = true;
                break;
            case (int)LimbType.p2RightArm:
                if ((player2RightArm = GetLimb()) != "") hasChecked = true;
                break;
            case (int)LimbType.p2LeftLeg:
                if ((player2LeftLeg = GetLimb()) != "") hasChecked = true;
                break;
            case (int)LimbType.p2RightLeg:
                if ((player2RightLeg = GetLimb()) != "") hasChecked = true;
                break;
            default:
                Debug.LogError("O fugg, something went really wrong");
                break;
        }
        if (hasChecked) checkedIndex++;
        DisplayInstructions(checkedIndex);
        if (checkedIndex < 9) Invoke("CheckLimbs", invokeTimer);
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

    private string GetLimb()
    {
        if(CheckAxis("LeftStickVertical", 0.3f)){
            return ConfirmSelected("LeftStickVertical");
        }
        if (CheckAxis("RightStickVertical", 0.3f))
        {
            return ConfirmSelected("RightStickVertical");
        }
        if (CheckAxis("LeftStickHorizontal", 0.3f))
        {
            return ConfirmSelected("LeftStickHorizontal");
        }
        if (CheckAxis("RightStickHorizontal", 0.3f))
        {
            return ConfirmSelected("RightStickHorizontal");
        }


        if (CheckAxis("P2LeftStickVertical", 0.3f))
        {
            return ConfirmSelected("P2LeftStickVertical");
        }
        if (CheckAxis("P2RightStickVertical", 0.3f))
        {
            return ConfirmSelected("P2RightStickVertical");
        }
        if (CheckAxis("P2LeftStickHorizontal", 0.3f))
        {
            return ConfirmSelected("P2LeftStickHorizontal");
        }
        if (CheckAxis("P2RightStickHorizontal", 0.3f))
        {
            return ConfirmSelected("P2RightStickHorizontal");
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

    private string ConfirmSelected(string selected)
    {
        if(selected == player1LeftArm 
            || selected == player1RightArm 
            || selected == player1LeftLeg 
            || selected == player1LeftLeg 
            || selected == player1RightLeg
            || selected == player2LeftArm
            || selected == player2RightArm
            || selected == player2LeftLeg
            || selected == player2RightLeg)
        {
            return "";
        } else
        {
            return selected;
        }
        
    }                  
}