using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCanvasController : MonoBehaviour {

    public GameObject player1Text;
    public GameObject player2Text;
    public GameObject tieText;

    void Start () {
        player1Text.SetActive(false);
        player2Text.SetActive(false);
        tieText.SetActive(false);
    }
	
    public void ShowWinText() {
        if (PlayerPrefs.GetInt(ScoringSystem.firstPlayerScoreKey) > PlayerPrefs.GetInt(ScoringSystem.secondPlayerScoreKey)) {
            player1Text.SetActive(true);
            GameObject.FindGameObjectWithTag("Head").GetComponent<FaceFeedback>().BeHappy();
            GameObject.FindGameObjectWithTag("HeadP2").GetComponent<FaceFeedback>().BeSad();
        }
        else if (PlayerPrefs.GetInt(ScoringSystem.firstPlayerScoreKey) < PlayerPrefs.GetInt(ScoringSystem.secondPlayerScoreKey)) {
            player2Text.SetActive(true);
            GameObject.FindGameObjectWithTag("Head").GetComponent<FaceFeedback>().BeSad();
            GameObject.FindGameObjectWithTag("HeadP2").GetComponent<FaceFeedback>().BeHappy();
        }
        else {
            tieText.SetActive(true);
            GameObject.FindGameObjectWithTag("Head").GetComponent<FaceFeedback>().BeHappy();
            GameObject.FindGameObjectWithTag("HeadP2").GetComponent<FaceFeedback>().BeHappy();
        }
    }
}
