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
        if (PlayerPrefs.GetInt(ScoringSystem.firstPlayerScoreKey, 0) > PlayerPrefs.GetInt(ScoringSystem.secondPlayerScoreKey, 0))
        {
            playerOneSpawn.transform.position = outsideScreen;
        } else
        {
            playerTwoSpawn.transform.position = outsideScreen;
        }
    }
}
