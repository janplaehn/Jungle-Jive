using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardPlayerSpawn : MonoBehaviour {
    public GameObject playerOneSpawn;
    public GameObject playerTwoSpawn;
    public Vector3 outsideScreen;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt(ScoringSystem.firstPlayerScoreKey, 1) > PlayerPrefs.GetInt(ScoringSystem.secondPlayerScoreKey, 0))
        {
            playerTwoSpawn.transform.position = outsideScreen;
        } else
        {
            playerOneSpawn.transform.position = outsideScreen;
        }
    }
}
