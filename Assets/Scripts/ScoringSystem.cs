using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour {
    public static string firstPlayerScoreKey = "FirstPlayerScore";
    public static string secondPlayerScoreKey = "SecondPlayerScore";
    int firstPlayerScore = 0;
    int secondPlayerScore = 0;
    public Text firstPlayerScoreDisplay;
    public Text secondPlayerScoreDisplay;
    public GameObject firstPlayerTextFeedback;
    public GameObject secondPlayerTextFeedback;
    public GameObject firstPlayerHead;
    public GameObject secondPlayerHead;

    public void AddFirstPlayerScore(int scoreAmount, int maxScore) {
        firstPlayerScore += scoreAmount;
        firstPlayerScoreDisplay.text = firstPlayerScore.ToString();
        PlayerPrefs.SetInt(firstPlayerScoreKey, firstPlayerScore);
        firstPlayerTextFeedback.GetComponent<TextFeedback>().GiveTextFeedback(scoreAmount, maxScore);
        firstPlayerHead.GetComponent<FaceFeedback>().GiveFaceFeedback(scoreAmount, maxScore);
    }

    public void AddSecondPlayerScore(int scoreAmount, int maxScore) {
        secondPlayerScore += scoreAmount;
        secondPlayerScoreDisplay.text = secondPlayerScore.ToString();
        PlayerPrefs.SetInt(secondPlayerScoreKey, secondPlayerScore);
        secondPlayerTextFeedback.GetComponent<TextFeedback>().GiveTextFeedback(scoreAmount, maxScore);
        secondPlayerHead.GetComponent<FaceFeedback>().GiveFaceFeedback(scoreAmount, maxScore);
    }

    public int GetFirstPlayerScore() { return firstPlayerScore; }
    public int GetSecondPlayerScore() { return secondPlayerScore; }
}
