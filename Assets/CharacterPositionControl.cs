using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPositionControl : MonoBehaviour {

    public float minYPosition;
    public float pullBackForce;
    public GameObject[] feet = new GameObject[2];

    void Start () {
		
	}
	
	void Update () {
        foreach (GameObject foot in feet) {
            if (foot.transform.position.y <= minYPosition) {
                Debug.Log("Character too low, Pullback initiated");
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, pullBackForce));
            }
        }
    }

    void OnValidate() {
        if (feet.Length != 2) {
            Debug.LogWarning("Feet array must be 2");
            Array.Resize(ref feet, 2);
        }
    }
}
