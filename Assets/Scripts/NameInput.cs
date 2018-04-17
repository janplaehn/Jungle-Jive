using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameInput : MonoBehaviour {

    public GameObject[] letterGameObjects;

    [HideInInspector] public static string playerOneName;
    [HideInInspector] public static string playerTwoName;
    [HideInInspector] public static bool wasNameEntered;

    private GameObject currentLetter;
    private int currentLetterIndex;

	void Start () {
        foreach (GameObject go in letterGameObjects) {
            go.GetComponent<Text>().text = "A";
        }
        currentLetter = letterGameObjects[0];
        currentLetterIndex = 0;
        currentLetter.GetComponent<Text>().fontStyle = FontStyle.Bold;
    }

    public void NextLetter() {
        if (currentLetter.GetComponent<Text>().text == "Z") {
            currentLetter.GetComponent<Text>().text = "A";
        }
        else {
            currentLetter.GetComponent<Text>().text = ((char)(currentLetter.GetComponent<Text>().text[0] + 1)).ToString();
        }
    }

    public void PreviousLetter() {
        if (currentLetter.GetComponent<Text>().text == "A") {
            currentLetter.GetComponent<Text>().text = "Z";
        }
        else {
            currentLetter.GetComponent<Text>().text = ((char)(currentLetter.GetComponent<Text>().text[0] - 1)).ToString();
        }
    }

    public void ConfirmLetters(string Scene) {
        currentLetter.GetComponent<Text>().fontStyle = FontStyle.Normal;
        if (currentLetterIndex == letterGameObjects.Length - 1) {
            playerOneName = "";
            foreach (GameObject go in letterGameObjects) {
                playerOneName = playerOneName +  ((char)(go.GetComponent<Text>().text[0])).ToString();
            }
            Debug.Log(playerOneName + " entered");
            SceneManager.LoadScene(Scene);
        }
        else {
            currentLetter = letterGameObjects[currentLetterIndex + 1];
            currentLetterIndex++;
            currentLetter.GetComponent<Text>().fontStyle = FontStyle.Bold;
        }
    }

}
