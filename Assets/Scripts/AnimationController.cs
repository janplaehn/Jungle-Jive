using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    public bool isAnimated = true;

	void Start () {
        if (isAnimated) GetComponent<Animator>().speed = GameObject.Find("GameController").GetComponent<GameControlling>().animationSpeed;
        else GetComponent<Animator>().speed = 0;

    }
}
