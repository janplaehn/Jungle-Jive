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
    public Color highlightColor;
    public Color defaultColor;

    public Image buttonImage;
    public Sprite confirmNameImage;

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
        currentLetter.GetComponent<Text>().color = highlightColor;

        if (!hasPlayerOneHighscore && player == Player.Player1) {
            foreach (GameObject button in PlayerButtons) {
                button.gameObject.SetActive(false);
            }
            Canvas.gameObject.SetActive(false);
            namesEntered++;
            hasPlayerOneHighscore = true;
        }
        if (!hasPlayerTwoHighscore && player == Player.Player2) {
            foreach (GameObject button in PlayerButtons) {
                button.gameObject.SetActive(false);
            }
            Canvas.gameObject.SetActive(false);
            namesEntered++;
            hasPlayerTwoHighscore = true;
        }

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

    public void SkipInput(string Scene) {
        currentLetter.GetComponent<Text>().color = defaultColor;
        switch (player) {
            case Player.Player1:
                playerOneName = "";
                foreach (GameObject go in letterGameObjects) {
                    string randomLetter = GetRandomLetter().ToString();
                    playerOneName = playerOneName + randomLetter;
                    go.GetComponent<Text>().text = randomLetter;
                }
                Debug.Log(playerOneName + " entered");
                namesEntered++;
                break;
            case Player.Player2:
                playerTwoName = "";
                foreach (GameObject go in letterGameObjects) {
                    string randomLetter = GetRandomLetter().ToString();
                    playerTwoName = playerTwoName + randomLetter;
                    go.GetComponent<Text>().text = randomLetter;
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

    public void ConfirmLetters(string Scene) {
        currentLetter.GetComponent<Text>().color = defaultColor;
            if (currentLetterIndex == letterGameObjects.Length - 1) {
            switch (player) {
                case Player.Player1:
                    playerOneName = "";
                    foreach (GameObject go in letterGameObjects) {
                        playerOneName = playerOneName + ((go.GetComponent<Text>().text[0])).ToString();
                    }
                    Debug.Log(playerOneName + " entered");
                    namesEntered++;
                    break;
                case Player.Player2:
                    playerTwoName = "";
                    foreach (GameObject go in letterGameObjects) {
                        playerTwoName = playerTwoName + ((go.GetComponent<Text>().text[0])).ToString();
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
            if (currentLetterIndex == letterGameObjects.Length - 2) {
                buttonImage.sprite = confirmNameImage;
            }
            currentLetter = letterGameObjects[currentLetterIndex + 1];
            currentLetterIndex++;
            currentLetter.GetComponent<Text>().color = highlightColor;
        }
    }

    private char GetRandomLetter() {
        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return letters[Random.Range(0, letters.Length)];
    }

}
