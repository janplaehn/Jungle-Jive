﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbMovement : MonoBehaviour {

    public string joystickAxis;
    [Range(-180, 180)]  public float maxRotation;
    [Range(0, 360)] public float startRotation;
    public bool isPaused;
    public float lastRotation;

	void Start () {
        isPaused = false;
        transform.rotation = transform.rotation = Quaternion.Euler(0, 0, startRotation);
    }
	
	void Update () {
        if (isPaused == false)
        {
            lastRotation = transform.rotation.eulerAngles.z;
            transform.rotation = transform.rotation = Quaternion.Euler(0, 0, Input.GetAxis(joystickAxis) * maxRotation + startRotation);

        }
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
        if (gameObject.tag == "RightArm" || gameObject.tag == "RightLeg" || gameObject.tag == "RightArmP2" || gameObject.tag == "RightLegP2") tempLimbState -= 2; tempLimbState = Mathf.Abs(tempLimbState);
        return tempLimbState;
    }
}
