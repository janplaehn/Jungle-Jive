using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoLights : MonoBehaviour {

    public Transform rotationPoint;
    public float rotationSpeed;
    public float maxRotation;
    public bool isReversed;

    private Vector3 rotationVector;

    void Start () {
        if (isReversed) {
            rotationVector = Vector3.back;
        }
        else {
            rotationVector = Vector3.forward;
        }
    }
	
	void Update () {
        transform.RotateAround(rotationPoint.position, rotationVector, rotationSpeed * Time.deltaTime);
        if (transform.rotation.eulerAngles.z < 360 - maxRotation && transform.rotation.eulerAngles.z > maxRotation + 20) {
            rotationVector = Vector3.forward;
        }
        if (transform.rotation.eulerAngles.z < 360 - maxRotation - 20 && transform.rotation.eulerAngles.z > maxRotation) {
            rotationVector = Vector3.back;
        }
    }
}
