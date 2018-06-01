using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCanvasController : MonoBehaviour {

    public GameObject player1Text;
    public GameObject player2Text;
    public GameObject tieText;

    public AudioSource audioSource;
    public AudioClip bridgetWin;
    public AudioClip jakobWin;
    public AudioClip hectorWin;
    public AudioClip IsabellWin;
    public AudioClip MonicaWin;

    void Start () {
        player1Text.SetActive(false);
        player2Text.SetActive(false);
        tieText.SetActive(false);
    }
	
    public void ShowWinText() {
        if (PlayerPrefs.GetInt(ScoringSystem.firstPlayerScoreKey) > PlayerPrefs.GetInt(ScoringSystem.secondPlayerScoreKey)) {
            PlayWinClip(true);
            player1Text.SetActive(true);
            if (GameObject.FindGameObjectWithTag("Head").GetComponent<FaceFeedback>())
            GameObject.FindGameObjectWithTag("Head").GetComponent<FaceFeedback>().BeHappy();
            if (GameObject.FindGameObjectWithTag("HeadP2").GetComponent<FaceFeedback>())
                GameObject.FindGameObjectWithTag("HeadP2").GetComponent<FaceFeedback>().BeSad();
        }
        else if (PlayerPrefs.GetInt(ScoringSystem.firstPlayerScoreKey) < PlayerPrefs.GetInt(ScoringSystem.secondPlayerScoreKey)) {
            PlayWinClip(false);
            player2Text.SetActive(true);
            if (GameObject.FindGameObjectWithTag("Head").GetComponent<FaceFeedback>())
                GameObject.FindGameObjectWithTag("Head").GetComponent<FaceFeedback>().BeSad();
            if (GameObject.FindGameObjectWithTag("HeadP2").GetComponent<FaceFeedback>())
                GameObject.FindGameObjectWithTag("HeadP2").GetComponent<FaceFeedback>().BeHappy();
        }
        else {
            tieText.SetActive(true);
            if (GameObject.FindGameObjectWithTag("Head").GetComponent<FaceFeedback>())
                GameObject.FindGameObjectWithTag("Head").GetComponent<FaceFeedback>().BeHappy();
            if (GameObject.FindGameObjectWithTag("HeadP2").GetComponent<FaceFeedback>())
                GameObject.FindGameObjectWithTag("HeadP2").GetComponent<FaceFeedback>().BeHappy();
        }
    }

    void PlayWinClip(bool isFirstPlayer)
    {
        string playerName;
        if (isFirstPlayer == true) playerName = GameObject.FindGameObjectWithTag("Player1").name;
        else playerName = GameObject.FindGameObjectWithTag("Player2").name;
        switch (playerName)
        {
            case "Bridget_PlayerOne(Clone)":
                audioSource.PlayOneShot(bridgetWin);
                break;
            case "Jakob_PlayerOne(Clone)":
                audioSource.PlayOneShot(jakobWin);
                break;
            case "Hector_PlayerOne(Clone)":
                audioSource.PlayOneShot(hectorWin);
                break;
            case "Isabell_PlayerOne(Clone)":
                audioSource.PlayOneShot(IsabellWin);
                break;
            case "Monica_PlayerOne(Clone)":
                audioSource.PlayOneShot(MonicaWin);
                break;
            default:
                break;
        }
    }
}
