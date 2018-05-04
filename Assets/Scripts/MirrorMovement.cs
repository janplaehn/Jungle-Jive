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

    public void SetInverted(bool isInverted) {
        if (isInverted) {
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
