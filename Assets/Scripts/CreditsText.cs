using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsText : MonoBehaviour {

    public string person;
    public string role;
    public float coolDownTime;

    private float timeInScene;

	void Start () {
        timeInScene = coolDownTime;
        this.GetComponent<Text>().text = person;
	}

    private void Update() {
        timeInScene -= Time.deltaTime;
        if (timeInScene >= 0) {
            this.GetComponent<Text>().text = person;
        }
    }
    public void ChangeTextState() {
        this.GetComponent<Text>().text = role;
        Invoke(("ChangeTextBack"), coolDownTime);
    }

    void ChangeTextBack() {
        this.GetComponent<Text>().text = person;
    }
}
