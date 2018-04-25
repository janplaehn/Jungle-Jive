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
        this.GetComponent<Text>().text = role;
        Invoke(("ChangeTextBack"), 2f);
    }

    void ChangeTextBack() {
        this.GetComponent<Text>().text = person;
    }
}
