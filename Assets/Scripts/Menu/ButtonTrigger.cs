using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTrigger : MonoBehaviour {

    public float chargeTime;
    public GameObject button;
    public GameObject chargeBar;
    public GameObject[] buttonDisplayObjects;

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
            chargeBar.GetComponent<AudioSource>().Play();
            foreach (GameObject button in buttonDisplayObjects) {
                if(button.GetComponent<SpriteRenderer>()) button.GetComponent<SpriteRenderer>().color = new Color32(200,200,200, 255);
                if (button.GetComponent<Image>()) button.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "hand") {
            isCharging = false;
            chargeBar.GetComponent<AudioSource>().Stop();
            foreach (GameObject button in buttonDisplayObjects) {
                if (button.GetComponent<SpriteRenderer>()) button.GetComponent<SpriteRenderer>().color = Color.white;
                if (button.GetComponent<Image>()) button.GetComponent<Image>().color = Color.white;
            }
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
