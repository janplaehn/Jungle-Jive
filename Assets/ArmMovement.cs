using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour {

    public string joystickAxis;
    [Range(-180, 180)]  public float maxRotation;
    [Range(0, 360)] public float startRotation;

	void Start () {
        transform.rotation = transform.rotation = Quaternion.Euler(0, 0, startRotation);
    }
	
	void Update () {
        transform.rotation = transform.rotation = Quaternion.Euler(0, 0, Input.GetAxis(joystickAxis) * maxRotation + startRotation);
    }
}
