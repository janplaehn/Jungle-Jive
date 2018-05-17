using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAfter : MonoBehaviour {
    public float killTimer;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, killTimer);
	}
}
