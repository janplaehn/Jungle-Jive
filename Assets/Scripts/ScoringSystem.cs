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
        if (firstPlayerTextFeedback == null)
        {
            firstPlayerTextFeedback = GameObject.FindGameObjectWithTag("Player1Feedback");
        }
        if(firstPlayerTextFeedback.GetComponent<TextFeedback>() != null)
        firstPlayerTextFeedback.GetComponent<TextFeedback>().GiveTextFeedback(scoreAmount, maxScore);
        if(firstPlayerHead == null)
        {
            firstPlayerHead = GameObject.FindGameObjectWithTag("Head");
        }
        firstPlayerHead.GetComponent<FaceFeedback>().GiveFaceFeedback(scoreAmount, maxScore);
        foreach (GameObject face in GameObject.FindGameObjectsWithTag("FeedbackFace1")) {
            if (face.GetComponent<AudienceFeedbackController>())
                face.GetComponent<AudienceFeedbackController>().GiveFaceFeedback(scoreAmount, maxScore);
        }
    }

    public void AddSecondPlayerScore(int scoreAmount, int maxScore) {
        secondPlayerScore += scoreAmount;
        secondPlayerScoreDisplay.text = secondPlayerScore.ToString();
        PlayerPrefs.SetInt(secondPlayerScoreKey, secondPlayerScore);
        if (secondPlayerTextFeedback == null)
        {
            secondPlayerTextFeedback = GameObject.FindGameObjectWithTag("Player2Feedback");
        }
        secondPlayerTextFeedback.GetComponent<TextFeedback>().GiveTextFeedback(scoreAmount, maxScore);
        if (secondPlayerHead == null)
        {
            secondPlayerHead = GameObject.FindGameObjectWithTag("HeadP2");
        }
        secondPlayerHead.GetComponent<FaceFeedback>().GiveFaceFeedback(scoreAmount, maxScore);
        foreach (GameObject face in GameObject.FindGameObjectsWithTag("FeedbackFace2")) {
            if (face.GetComponent<AudienceFeedbackController>())
            face.GetComponent<AudienceFeedbackController>().GiveFaceFeedback(scoreAmount, maxScore);
        }
    }

    public int GetFirstPlayerScore() { return firstPlayerScore; }
    public int GetSecondPlayerScore() { return secondPlayerScore; }
}
