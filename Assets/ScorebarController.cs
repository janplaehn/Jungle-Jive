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
        PlayerPrefs.SetInt("SecondPlayerScore", 0);
        PlayerPrefs.SetInt("FirstPlayerScore", 0);
    }
	
	void Update () {
        CalculateScoreBalance();	
	}

    void CalculateScoreBalance() {
        image.fillAmount = 0.5f;
        firstPlayerScore = PlayerPrefs.GetInt("FirstPlayerScore", 0);
        secondPlayerScore = PlayerPrefs.GetInt("SecondPlayerScore", 0);
        if (firstPlayerScore + secondPlayerScore != 0) {
            image.fillAmount = firstPlayerScore / (firstPlayerScore + secondPlayerScore);
        }
        Debug.Log(image.fillAmount);
    }
}
