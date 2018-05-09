using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlling : MonoBehaviour {
    public GameState stateManager;
    public AudioClip music;
    public float animationSpeed = 1;
    public float moveReactionTime;
    private bool isPaused;



    void Start() {
        isPaused = false;
        CreateInstructions();
    }

    void Update() {
       
    }

    public void GameOver() {
        GameObject.Find("WinCanvas").GetComponent<WinCanvasController>().ShowWinText();
        foreach (GameObject face in GameObject.FindGameObjectsWithTag("FeedbackFace1")) {
            if (face.GetComponent<AudienceFeedbackController>())
                face.GetComponent<AudienceFeedbackController>().BeHappy();
        }
        foreach (GameObject face in GameObject.FindGameObjectsWithTag("FeedbackFace2")) {
            if (face.GetComponent<AudienceFeedbackController>())
                face.GetComponent<AudienceFeedbackController>().BeHappy();
        }
        if (GameObject.Find("MusicManager")) {
            GameObject.Find("MusicManager").GetComponent<MusicManagement>().Stop("DanceMusic");
            GameObject.Find("MusicManager").GetComponent<MusicManagement>().Play("MenuMusic");
        }
        Invoke("QuitToLeaderboard", 5f);
        if (GetComponent<AudioSource>()) GetComponent<AudioSource>().Play();
    }

    private void QuitToLeaderboard() {
        SceneManager.LoadScene("EnterNameScene");
    }

    void CreateInstructions()
    {
    }
    

    


}