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
	
	void Update () {
        if (isCharging) {
            timeLeft -= Time.deltaTime;
        }
        else {
            timeLeft = chargeTime;
        }
        if (timeLeft <= 0) {
            timeLeft = chargeTime;
            button.GetComponent<Button>().onClick.Invoke();
        }
        SetChargeBarWidth();
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "hand") {
            isCharging = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "hand") {
            isCharging = false;
        }
    }

    public void SetChargeBarWidth() {
        if (timeLeft > 0) {
            float NewWidth = 100 - timeLeft / chargeTime * 100;
            chargeBar.GetComponent<RectTransform>().sizeDelta = new Vector2(NewWidth, chargeBar.GetComponent<RectTransform>().sizeDelta.y);
        }
    }
}
