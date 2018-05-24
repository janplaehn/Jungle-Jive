using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControllerManager : MonoBehaviour {
    public string player1LeftArm;
    public string player1RightArm;
    public string player1LeftLeg;
    public string player1RightLeg;
    public string player2LeftArm;
    public string player2RightArm;
    public string player2LeftLeg;
    public string player2RightLeg;

    public static string keyPlayer1LeftArm = "Player1LeftArm";
    public static string keyPlayer1RightArm = "Player1RightArm";
    public static string keyPlayer1LeftLeg = "Player1LeftLeg";
    public static string keyPlayer1RightLeg = "Player1RightLeg";
    public static string keyPlayer2LeftArm = "Player2LeftArm";
    public static string keyPlayer2RightArm = "Player2RightArm";
    public static string keyPlayer2LeftLeg = "Player2LeftLeg";
    public static string keyPlayer2RightLeg = "Player2RightLeg";

    public float invokeTimer;
    public Text instructionText;
    private int checkedIndex = 0;

    private float checkThreshold = 0.3f;

    public enum LimbType
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
        DisplayLimbState();
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
        if (checkedIndex < 8) {
            Invoke("CheckLimbs", invokeTimer);
        } else
        {
            PlayerPrefs.SetString(keyPlayer1LeftArm, player1LeftArm);
            PlayerPrefs.SetString(keyPlayer1RightArm, player1RightArm);
            PlayerPrefs.SetString(keyPlayer1LeftLeg, player1LeftLeg);
            PlayerPrefs.SetString(keyPlayer1RightLeg, player1RightLeg);
            PlayerPrefs.SetString(keyPlayer2LeftArm, player2LeftArm);
            PlayerPrefs.SetString(keyPlayer2RightArm, player2RightArm);
            PlayerPrefs.SetString(keyPlayer2LeftLeg, player2LeftLeg);
            PlayerPrefs.SetString(keyPlayer2RightLeg, player2RightLeg);
        }
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

    private void DisplayLimbState()
    {
        Debug.Log("LeftStickVertical : " + Input.GetAxis("LeftStickVertical"));
        Debug.Log("RightStickVertical : " + Input.GetAxis("RightStickVertical"));
        Debug.Log("LeftStickHorizontal : " + Input.GetAxis("LeftStickHorizontal"));
        Debug.Log("RightStickHorizontal : " + Input.GetAxis("RightStickHorizontal"));

        Debug.Log("LeftStickVertical2 : " + Input.GetAxis("LeftStickVertical2"));
        Debug.Log("RightStickVertical2 : " + Input.GetAxis("RightStickVertical2"));
        Debug.Log("LeftStickHorizontal2 : " + Input.GetAxis("LeftStickHorizontal2"));
        Debug.Log("RightStickHorizontal2 : " + Input.GetAxis("RightStickHorizontal2"));

        Debug.Log("P2LeftStickVertical : " + Input.GetAxis("P2LeftStickVertical"));
        Debug.Log("P2RightStickVertical : " + Input.GetAxis("P2RightStickVertical"));
        Debug.Log("P2LeftStickHorizontal : " + Input.GetAxis("P2LeftStickHorizontal"));
        Debug.Log("P2RightStickHorizontal : " + Input.GetAxis("P2RightStickHorizontal"));

        Debug.Log("P2LeftStickVertical2 : " + Input.GetAxis("P2LeftStickVertical2"));
        Debug.Log("P2RightStickVertical2 : " + Input.GetAxis("P2RightStickVertical2"));
        Debug.Log("P2LeftStickHorizontal2 : " + Input.GetAxis("P2LeftStickHorizontal2"));
        Debug.Log("P2RightStickHorizontal2 : " + Input.GetAxis("P2RightStickHorizontal2"));
    }

    private string GetLimb(bool isLeg)
    {
        if(CheckAxis("LeftStickVertical", checkThreshold)){
            if(ConfirmAxis("LeftStickVertical") != "") return "LeftStickVertical";
        }
        if (CheckAxis("RightStickVertical", checkThreshold))
        {
            if (ConfirmAxis("RightStickVertical") != "") return "RightStickVertical";
        }
        if (CheckAxis("LeftStickHorizontal", checkThreshold))
        {
            if (ConfirmAxis("LeftStickHorizontal") != "") return "LeftStickHorizontal";
        }
        if (CheckAxis("RightStickHorizontal", checkThreshold))
        {
            if (ConfirmAxis("RightStickHorizontal") != "") return "RightStickHorizontal";
        }


        if (CheckAxis("LeftStickVertical2", checkThreshold))
        {
            if (ConfirmAxis("LeftStickVertical2") != "") return "LeftStickVertical2";
        }
        if (CheckAxis("RightStickVertical2", checkThreshold))
        {
            if (ConfirmAxis("RightStickVertical2") != "") return "RightStickVertical2";
        }
        if (CheckAxis("LeftStickHorizontal2", checkThreshold))
        {
            if (ConfirmAxis("LeftStickHorizontal2") != "") return "LeftStickHorizontal2";
        }
        if (CheckAxis("RightStickHorizontal2", checkThreshold))
        {
            if (ConfirmAxis("RightStickHorizontal2") != "") return "RightStickHorizontal2";
        }


        if (CheckAxis("P2LeftStickVertical", checkThreshold))
        {
            if (ConfirmAxis("P2LeftStickVertical") != "") return "P2LeftStickVertical";
        }
        if (CheckAxis("P2RightStickVertical", checkThreshold))
        {
            if (ConfirmAxis("P2RightStickVertical") != "") return "P2RightStickVertical";
        }
        if (CheckAxis("P2LeftStickHorizontal", checkThreshold))
        {
            if (ConfirmAxis("P2LeftStickHorizontal") != "") return "P2LeftStickHorizontal";
        }
        if (CheckAxis("P2RightStickHorizontal", checkThreshold))
        {
            if (ConfirmAxis("P2RightStickHorizontal") != "") return "P2RightStickHorizontal";
        }

        if (CheckAxis("P2LeftStickVertical2", checkThreshold))
        {
            if (ConfirmAxis("P2LeftStickVertical2") != "") return "P2LeftStickVertical2";
        }
        if (CheckAxis("P2RightStickVertical2", checkThreshold))
        {
            if (ConfirmAxis("P2RightStickVertical2") != "") return "P2RightStickVertical2";
        }
        if (CheckAxis("P2LeftStickHorizontal2", checkThreshold))
        {
            if (ConfirmAxis("P2LeftStickHorizontal2") != "") return "P2LeftStickHorizontal2";
        }
        if (CheckAxis("P2RightStickHorizontal2", checkThreshold))
        {
            if (ConfirmAxis("P2RightStickHorizontal2") != "") return "P2RightStickHorizontal2";
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
            || axis == player1RightArm || axis == player1RightArm + "2" || axis == TrimEnd(player1RightArm)
            || axis == player1LeftLeg  || axis == player1LeftLeg + "2" || axis == TrimEnd(player1LeftLeg)
            || axis == player1RightLeg || axis == player1RightLeg + "2" || axis == TrimEnd(player1RightLeg)
            || axis == player2LeftArm || axis == player2LeftArm + "2" || axis == TrimEnd(player2LeftArm)
            || axis == player2RightArm || axis == player2RightArm + "2" || axis == TrimEnd(player2RightArm)
            || axis == player2LeftLeg || axis == player2LeftLeg + "2" || axis == TrimEnd(player2LeftLeg)
            || axis == player2RightLeg || axis == player2RightLeg + "2" || axis == TrimEnd(player2RightLeg))
        {
            return "";
        } else
        {
            return axis;
        }
    }

    private string TrimEnd(string original)
    {
        string result = "";
        for(int i = 0; i < original.Length - 1; i++)
        {
            result += original[i];
        }

        return result;
    }
}