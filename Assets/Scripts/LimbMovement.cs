using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbMovement : MonoBehaviour {
    private string joystickAxis;
    [Range(-180, 180)]  public float maxRotation;
    [Range(0, 360)] public float startRotation;
    public bool isPaused;
    private float stunTime;
    public float lastRotation;
    [HideInInspector] public float inversion = 1;
    private static float dampenThreshold = 1f;
    private float accumulatedTime;

	void Start () {
        stunTime = -1;
        isPaused = false;
        transform.rotation = transform.rotation = Quaternion.Euler(0, 0, startRotation);
        joystickAxis = GetAxis();
    }
	
	void Update () {
        if (isPaused == false)
        {
            lastRotation = transform.rotation.eulerAngles.z;
            float currentRotation = Input.GetAxis(joystickAxis) * maxRotation * inversion + startRotation;
            if(Mathf.Abs(currentRotation - lastRotation) > dampenThreshold) transform.rotation = Quaternion.Euler(0, 0, Input.GetAxis(joystickAxis) * maxRotation * inversion + startRotation);
        } else if (isPaused == true && stunTime != -1)
        {
            accumulatedTime += Time.deltaTime;
            if (stunTime <= accumulatedTime)
            {
                isPaused = false;
                stunTime = -1;
            }
        }
        
    }

    private string GetAxis()
    {
        if (gameObject.tag == "RightArm" || gameObject.transform.parent.gameObject.tag == "RightArm") return PlayerPrefs.GetString(ControllerManager.keyPlayer1RightArm, "LeftStickVertical");
        if (gameObject.tag == "RightArmP2" || gameObject.transform.parent.gameObject.tag == "RightArmP2") return PlayerPrefs.GetString(ControllerManager.keyPlayer2RightArm, "LeftStickVertical");
        if (gameObject.tag == "LeftArm" || gameObject.transform.parent.gameObject.tag == "LeftArm") return PlayerPrefs.GetString(ControllerManager.keyPlayer1LeftArm, "LeftStickVertical");
        if (gameObject.tag == "LeftArmP2" || gameObject.transform.parent.gameObject.tag == "LeftArmP2") return PlayerPrefs.GetString(ControllerManager.keyPlayer2LeftArm, "LeftStickVertical");
        if (gameObject.tag == "RightLeg" || gameObject.transform.parent.gameObject.tag == "RightLeg") return PlayerPrefs.GetString(ControllerManager.keyPlayer1RightLeg, "LeftStickVertical");
        if (gameObject.tag == "RightLegP2" || gameObject.transform.parent.gameObject.tag == "RightLegP2") return PlayerPrefs.GetString(ControllerManager.keyPlayer2RightLeg, "LeftStickVertical");
        if (gameObject.tag == "LeftLeg" || gameObject.transform.parent.gameObject.tag == "LeftLeg") return PlayerPrefs.GetString(ControllerManager.keyPlayer1LeftLeg, "LeftStickVertical");
        if (gameObject.tag == "LeftLegP2" || gameObject.transform.parent.gameObject.tag == "LeftLegP2") return PlayerPrefs.GetString(ControllerManager.keyPlayer2LeftLeg, "LeftStickVertical");
        return "";
    }
    public int GetLimbState()
    {
        int tempLimbState = -1;
        if (Mathf.DeltaAngle(transform.rotation.eulerAngles.z, startRotation) < 30 && Mathf.DeltaAngle(transform.rotation.eulerAngles.z, startRotation) > -30)
        {
            tempLimbState = 1;
        } else if (Mathf.DeltaAngle(transform.rotation.eulerAngles.z, startRotation) >= 30)
        {
            tempLimbState = 0;
        } else if (Mathf.DeltaAngle(transform.rotation.eulerAngles.z, startRotation) <= -30)
        {
            tempLimbState = 2;
        }
        if (gameObject.tag == "RightArm" || gameObject.tag == "RightLeg" || gameObject.tag == "RightArmP2" || gameObject.tag == "RightLegP2") tempLimbState -= 2;
        tempLimbState = Mathf.Abs(tempLimbState);
        return tempLimbState;
    }

    public void SetStun (float pauseTime)
    {
        stunTime = pauseTime;
        isPaused = true;
    }
}
