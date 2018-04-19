using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsText : MonoBehaviour {

    public string person;
    public string role;

	void Start () {
        this.GetComponent<Text>().text = person;
	}
	
    public void ChangeTextState() {
        if (this.GetComponent<Text>().text == person) {
            this.GetComponent<Text>().text = role;
        }
        else if (this.GetComponent<Text>().text == role) {
            this.GetComponent<Text>().text = person;
        }
        else {
            Debug.LogWarning("Unknown Text Format");
        }
    }
}
