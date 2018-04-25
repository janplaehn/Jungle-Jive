using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

	void Start () {
        GetComponent<Animator>().speed = GameObject.Find("GameController").GetComponent<GameControlling>().animationSpeed;
	}
}
