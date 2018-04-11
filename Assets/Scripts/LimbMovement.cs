using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbMovement : MonoBehaviour {

    public string joystickAxis;
    [Range(-180, 180)]  public float maxRotation;
    [Range(0, 360)] public float startRotation;

	void Start () {
        transform.rotation = transform.rotation = Quaternion.Euler(0, 0, startRotation);
    }
	
	void Update () {
        transform.rotation = transform.rotation = Quaternion.Euler(0, 0, Input.GetAxis(joystickAxis) * maxRotation + startRotation);
    }

    public int GetLimbState()
    {
        int tempLimbState = -1;
        if (Mathf.DeltaAngle(transform.rotation.eulerAngles.z, startRotation) < 40 && Mathf.DeltaAngle(transform.rotation.eulerAngles.z, startRotation) > -40)
        {
            tempLimbState = 1;
        } else if (Mathf.DeltaAngle(transform.rotation.eulerAngles.z, startRotation) >= 40)
        {
            tempLimbState = 0;
        } else if (Mathf.DeltaAngle(transform.rotation.eulerAngles.z, startRotation) <= -40)
        {
            tempLimbState = 2;
        }
        if (gameObject.tag == "RightArm") tempLimbState -= 2; tempLimbState = Mathf.Abs(tempLimbState);
        return tempLimbState;
    }//TODO: get number based on rotation
}
