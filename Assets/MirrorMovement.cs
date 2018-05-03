using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorMovement : MonoBehaviour {

    [HideInInspector] public bool isMirrored = false;

	void Start () {
        isMirrored = false;
	}
	
	void Update () {
        SetMirror();
	}

    void SetMirror() {
        if (isMirrored) {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
