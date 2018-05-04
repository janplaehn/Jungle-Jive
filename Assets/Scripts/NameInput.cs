using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameInput : MonoBehaviour {

    public enum Player {Player1, Player2};
    public Player player;
    [Header("GameObjects")]
    public GameObject[] letterGameObjects;
    public GameObject[] PlayerButtons;
    public GameObject Canvas;

    [HideInInspector] public static string playerOneName;
    [HideInInspector] public static string playerTwoName;
    [HideInInspector] public static bool wasNameEntered;
    [HideInInspector] public static bool hasPlayerOneHighscore = true;
    [HideInInspector] public static bool hasPlayerTwoHighscore = true;

    private static int namesEntered = 0;
    private GameObject currentLetter;
    private int currentLetterIndex;

	void Awake () {

        int[] temp = new int[10];
        for (int i = temp.Length - 1; i >= 0; i--) {
            temp[i] = PlayerPrefs.GetInt("HighScore" + i.ToString(), (i + 1) * 100);
            PlayerPrefs.SetInt("HighScore" + i.ToString(), temp[i]);
        }
        if (temp[0] < PlayerPrefs.GetInt(ScoringSystem.firstPlayerScoreKey, 0) || temp[0] < PlayerPrefs.GetInt(ScoringSystem.secondPlayerScoreKey, 0)) {
            if (temp[0] > PlayerPrefs.GetInt(ScoringSystem.firstPlayerScoreKey, 0)) {
                hasPlayerOneHighscore = false;
            }
            else {
                hasPlayerOneHighscore = true;
            }
            if (temp[0] > PlayerPrefs.GetInt(ScoringSystem.secondPlayerScoreKey, 0)) {
                hasPlayerTwoHighscore = false;
            }
            else {
                hasPlayerTwoHighscore = true;
            }
            wasNameEntered = true;
        }
        else {
            SceneManager.LoadScene("LeaderboardScene");
            wasNameEntered = false;
        }

        foreach (GameObject go in letterGameObjects) {
            go.GetComponent<Text>().text = "A";
        }
        currentLetter = letterGameObjects[0];
        currentLetterIndex = 0;
        currentLetter.GetComponent<Text>().fontStyle = FontStyle.Bold;

        if (!hasPlayerOneHighscore && player == Player.Player1) {
            foreach (GameObject button in PlayerButtons) {
                button.gameObject.SetActive(false);
            }
            //Character.gameObject.SetActive(false);
            Canvas.gameObject.SetActive(false);
            namesEntered++;
            hasPlayerOneHighscore = true;
        }
        if (!hasPlayerTwoHighscore && player == Player.Player2) {
            foreach (GameObject button in PlayerButtons) {
                button.gameObject.SetActive(false);
            }
            //Character.gameObject.SetActive(false);
            Canvas.gameObject.SetActive(false);
            namesEntered++;
            hasPlayerTwoHighscore = true;
        }
    }

    //private void Update()
    //{
    //    if(Character == null)
    //    {
    //        if (player == Player.Player1) Character = GameObject.FindGameObjectWithTag("Player1");
    //        if (player == Player.Player2) Character = GameObject.FindGameObjectWithTag("Player2");
    //    }
    //}

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
            switch (player) {
                case Player.Player1:
                    playerOneName = "";
                    foreach (GameObject go in letterGameObjects) {
                        playerOneName = playerOneName + ((char)(go.GetComponent<Text>().text[0])).ToString();
                    }
                    Debug.Log(playerOneName + " entered");
                    namesEntered++;
                    break;
                case Player.Player2:
                    playerTwoName = "";
                    foreach (GameObject go in letterGameObjects) {
                        playerTwoName = playerTwoName + ((char)(go.GetComponent<Text>().text[0])).ToString();
                    }
                    Debug.Log(playerTwoName + " entered");
                    namesEntered++;
                    break;
                default:
                    break;
            }
            foreach (GameObject button in PlayerButtons) {
                button.gameObject.SetActive(false);
            }
            if (namesEntered >= 2) {
                namesEntered = 0;
                SceneManager.LoadScene(Scene);
            }
        }
        else {
            currentLetter = letterGameObjects[currentLetterIndex + 1];
            currentLetterIndex++;
            currentLetter.GetComponent<Text>().fontStyle = FontStyle.Bold;
        }
    }

}
