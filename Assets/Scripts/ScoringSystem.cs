using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour {
    int firstPlayerScore = 0;
    int secondPlayerScore = 0;
    public Text firstPlayerScoreDisplay;
    public Text secondPlayerScoreDisplay;
    public GameObject firstPlayerTextFeedback;
    public GameObject secondPlayerTextFeedback;

    public void AddFirstPlayerScore(int scoreAmount) {
        firstPlayerScore += scoreAmount;
        firstPlayerScoreDisplay.text = firstPlayerScore.ToString();
        firstPlayerTextFeedback.GetComponent<TextFeedback>().GiveTextFeedback(scoreAmount);
    }

    public void AddSecondPlayerScore(int scoreAmount) {
        secondPlayerScore += scoreAmount;
        secondPlayerScoreDisplay.text = secondPlayerScore.ToString();
        secondPlayerTextFeedback.GetComponent<TextFeedback>().GiveTextFeedback(scoreAmount);
    }

    public int GetFirstPlayerScore() { return firstPlayerScore; }
    public int GetSecondPlayerScore() { return secondPlayerScore; }
}
