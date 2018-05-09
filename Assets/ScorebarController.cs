using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorebarController : MonoBehaviour {

    private Image image;
    private float firstPlayerScore;
    private float secondPlayerScore;

    void Start () {
        image = GetComponent<Image>();
	}
	
	void Update () {
        CalculateScoreBalance();	
	}

    void CalculateScoreBalance() {
        firstPlayerScore = PlayerPrefs.GetInt("FirstPlayerScore", 0);
        secondPlayerScore = PlayerPrefs.GetInt("SecondPlayerScore", 0);
        if (firstPlayerScore + secondPlayerScore != 0) {
            image.fillAmount = firstPlayerScore / (firstPlayerScore + secondPlayerScore);
        }
        else {
            image.fillAmount = 0.5f;
        }
    }
}
