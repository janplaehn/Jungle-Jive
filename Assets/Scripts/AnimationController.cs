using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    public bool isAnimated = true;

	void Start () {
        if (isAnimated) {
            if (GameObject.Find("GameController").GetComponent<GameControlling>()) {
                GetComponent<Animator>().speed = GameObject.Find("GameController").GetComponent<GameControlling>().animationSpeed;
            }
            else {
                GetComponent<Animator>().speed = 1;
            }
        }
       
        else GetComponent<Animator>().speed = 0;

    }
}
