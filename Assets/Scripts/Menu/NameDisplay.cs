using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameDisplay : MonoBehaviour {

    [Range(1, 2)] public int player = 1;
    private Text textField;

	void Start () {
        textField = GetComponent<Text>();       
    }

    private void Update() {
        if (GameObject.FindGameObjectWithTag("Player1") && GameObject.FindGameObjectWithTag("Player2")) SetName();
    }

    public void SetName () {
        if (player == 1) textField.text = GameObject.FindGameObjectWithTag("Player1").GetComponent<Getbodyparts>().characterName;
        else if (player == 2) textField.text = GameObject.FindGameObjectWithTag("Player2").GetComponent<Getbodyparts>().characterName;
    }
}
