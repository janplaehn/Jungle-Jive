using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlling : MonoBehaviour {
    public GameState stateManager;
    public AudioClip music;
    public LightsFeedback lights;

    public float animationSpeed = 1;
    public float moveReactionTime;

    public void GameOver() {
        Invoke("QuitToLeaderboard", 8f);
        GameObject.Find("WinCanvas").GetComponent<WinCanvasController>().ShowWinText();
        foreach (GameObject face in GameObject.FindGameObjectsWithTag("FeedbackFace1")) {
            if (face.GetComponent<AudienceFeedbackController>())
                face.GetComponent<AudienceFeedbackController>().BeHappy();
        }
        foreach (GameObject face in GameObject.FindGameObjectsWithTag("FeedbackFace2")) {
            if (face.GetComponent<AudienceFeedbackController>())
                face.GetComponent<AudienceFeedbackController>().BeHappy();
        }
        if (GetComponent<AudioSource>()) GetComponent<AudioSource>().Play();
        StartCoroutine(ChangeMusic());
        Invoke("ShootAwayLosingPlayer", 1f);
    }

    private void QuitToLeaderboard() {
        SceneManager.LoadScene("EnterNameScene");
    }

    private void ShootAwayLosingPlayer() {
        if (PlayerPrefs.GetInt(ScoringSystem.firstPlayerScoreKey, 0) > PlayerPrefs.GetInt(ScoringSystem.secondPlayerScoreKey, 0)) {
            lights.LeftPlayerWins();
            Rigidbody2D losingPlayer = GameObject.FindGameObjectWithTag("Player2").GetComponent<Rigidbody2D>();
            losingPlayer.gravityScale = 0;
            losingPlayer.constraints = RigidbodyConstraints2D.None;
            losingPlayer.AddForce(new Vector3(1, 0.8f) * 500);
            losingPlayer.AddTorque(-500);
        }
        else if (PlayerPrefs.GetInt(ScoringSystem.firstPlayerScoreKey, 0) < PlayerPrefs.GetInt(ScoringSystem.secondPlayerScoreKey, 0)) {
            lights.RightPlayerWins();
            Rigidbody2D losingPlayer = GameObject.FindGameObjectWithTag("Player1").GetComponent<Rigidbody2D>();
            losingPlayer.constraints = RigidbodyConstraints2D.None;
            losingPlayer.gravityScale = 0;
            losingPlayer.AddForce(new Vector3(-1, 0.8f) * 500);
            losingPlayer.AddTorque(500);
        }
    }

    private IEnumerator ChangeMusic() {
        yield return new WaitForSeconds(2f);
        if (GameObject.Find("MusicManager")) {
            GameObject.Find("MusicManager").GetComponent<MusicManagement>().Stop("DanceMusic");
            GameObject.Find("MusicManager").GetComponent<MusicManagement>().Play("MenuMusic");
        }
    }

    


}