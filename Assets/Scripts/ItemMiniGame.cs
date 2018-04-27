using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMiniGame : State {

    public Vector3 birdSpawnPosition;
    public float miniGameTimer = 6f;
    public GameObject miniGameInstruction;
    public Transform bird;
    private GameObject playerOne;
    private GameObject playerTwo;
    private float playerOneScore;
    private float playerTwoScore;
    private InputCheck input;
    private bool finished = false;

    public override void OnStart () {
        playerOne = GameObject.FindGameObjectWithTag("Player1");
        playerTwo = GameObject.FindGameObjectWithTag("Player2");
        input = GameObject.Find("GameController").GetComponent<InputCheck>();
        Instantiate(bird, birdSpawnPosition, Quaternion.identity);
        Invoke("QuitState", miniGameTimer);
    }

    public override bool OnUpdate () {
        playerOneScore += input.GetShakingUp(InputCheck.Players.PlayerOne);
        playerTwoScore += input.GetShakingUp(InputCheck.Players.PlayerTwo);
        if(finished == true)
        {
            return false;
        }
        return true;
    }

    public override void OnEnd()
    {
        bird.gameObject.GetComponent<BirdControl>().state = BirdControl.FlightState.decided;
        if (playerOneScore > playerTwoScore) {
            bird.gameObject.GetComponent<BirdControl>().hasPlayerOneWon = true;
        }
        else {
            bird.gameObject.GetComponent<BirdControl>().hasPlayerOneWon = false;
        }
    }

    void QuitState() {
        finished = true;
    }
}
