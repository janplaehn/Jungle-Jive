using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTrigger : MonoBehaviour {

    public float chargeTime;
    public GameObject button;
    public GameObject chargeBar;

    private float timeLeft;
    private bool isCharging;
    private Animator chargeAnimator;

    private void Awake() {
        timeLeft = chargeTime;
        chargeAnimator = chargeBar.GetComponent<Animator>();
        chargeAnimator.speed = 1 / chargeTime;
    }

    void Update () {
        if (isCharging) {
            timeLeft -= Time.deltaTime;
        }
        else {
            timeLeft = chargeTime;
        }
        if (timeLeft <= 0 && isCharging) {
            timeLeft = chargeTime;
            button.GetComponent<Button>().onClick.Invoke();
        }
        SetChargeBarAnimation();
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "hand") {
            isCharging = true;
            timeLeft = chargeTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "hand") {
            isCharging = false;
        }
    }

    public void SetChargeBarAnimation() {
        if (isCharging) {
            chargeAnimator.Play("charging");
        }
        else {
            chargeAnimator.Play("idle");
        }
    }
}
