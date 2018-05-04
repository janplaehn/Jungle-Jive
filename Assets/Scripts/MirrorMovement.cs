using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorMovement : MonoBehaviour {

    [HideInInspector] public bool isMirrored = false;
    [HideInInspector] public LimbMovement[] movementScripts;

	void Start () {
        movementScripts = GetComponentsInChildren<LimbMovement>();
        isMirrored = false;
	}
	
	void Update () {
        SetMirror();
	}

    void SetMirror() {
        if (isMirrored) {
            foreach (LimbMovement script in movementScripts) {
                script.inversion = -1;
            }
        }
        else {
            foreach (LimbMovement script in movementScripts) {
                script.inversion = 1;
            }
        }
    }
}
