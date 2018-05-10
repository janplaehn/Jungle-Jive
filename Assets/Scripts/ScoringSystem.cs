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
    public GameObject comboManager;
    public static float comboMultiplierP1 = 1;
    public static float comboMultiplierP2 = 1;

    public void AddFirstPlayerScore(int scoreAmount, int maxScore) {
        firstPlayerScore += (int) (scoreAmount * comboMultiplierP1);
        firstPlayerScoreDisplay.text = firstPlayerScore.ToString();
        PlayerPrefs.SetInt(firstPlayerScoreKey, firstPlayerScore);
        if (firstPlayerTextFeedback == null)
        {
            firstPlayerTextFeedback = GameObject.FindGameObjectWithTag("Player1Feedback");
        }
        if(firstPlayerTextFeedback.GetComponent<TextFeedback>() != null)
        firstPlayerTextFeedback.GetComponent<TextFeedback>().GiveTextFeedback(scoreAmount, maxScore);
        if(!firstPlayerHead)
        {
            firstPlayerHead = GameObject.FindGameObjectWithTag("Head");
        }
        else if (firstPlayerHead) {
            if (firstPlayerHead.GetComponent<FaceFeedback>())
            firstPlayerHead.GetComponent<FaceFeedback>().GiveFaceFeedback(scoreAmount, maxScore);
        }
        foreach (GameObject face in GameObject.FindGameObjectsWithTag("FeedbackFace1")) {
            if (face.GetComponent<AudienceFeedbackController>())
                face.GetComponent<AudienceFeedbackController>().GiveFaceFeedback(scoreAmount, maxScore);
        }
        if (scoreAmount == maxScore) comboManager.GetComponent<ComboManager>().increaseCombo(true);
        else comboManager.GetComponent<ComboManager>().breakCombo(true);
    }

    public void AddSecondPlayerScore(int scoreAmount, int maxScore) {
        secondPlayerScore += (int)(scoreAmount * comboMultiplierP2);
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
        if (scoreAmount == maxScore) comboManager.GetComponent<ComboManager>().increaseCombo(false);
        else comboManager.GetComponent<ComboManager>().breakCombo(false);
    }

    public int GetFirstPlayerScore() { return firstPlayerScore; }
    public int GetSecondPlayerScore() { return secondPlayerScore; }
}
