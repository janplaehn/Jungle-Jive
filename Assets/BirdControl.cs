using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour {

    public float movementRadius;
    private int flightdirection;

	void Start () {
	    	
	}
	
	void Update () {
        transform.position += Vector3.right * movementRadius * Time.deltaTime;
	}
}
