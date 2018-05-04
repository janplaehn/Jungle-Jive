using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMiniGame : State {

    public Vector3 birdSpawnPosition;
    public float miniGameTimer = 6f;
    public GameObject miniGameInstruction;
    public Transform bird;

    private GameObject canvas;
    private GameObject playerOne;
    private GameObject playerTwo;
    private float playerOneScore;
    private float playerTwoScore;
    private InputCheck input;
    private bool finished = false;
    private GameObject birdInstance;


    public override void OnStart() {
        playerOne = GameObject.FindGameObjectWithTag("Player1");
        playerTwo = GameObject.FindGameObjectWithTag("Player2");
        canvas = GameObject.Find("Canvas");
        input = GameObject.Find("GameController").GetComponent<InputCheck>();
        birdInstance = Instantiate(bird, birdSpawnPosition, Quaternion.identity).gameObject;
        foreach (DiscoballRetract dr in canvas.GetComponentsInChildren<DiscoballRetract>()) {
            dr.Retract();
        }
        Invoke("BeforeEnd", miniGameTimer - 2);
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

    public void BeforeEnd() {
        foreach (DiscoballRetract dr in canvas.GetComponentsInChildren<DiscoballRetract>()) {
            dr.Extend();
        }
        birdInstance.gameObject.GetComponent<BirdControl>().state = BirdControl.FlightState.decided;
        if (playerOneScore > playerTwoScore) {
            birdInstance.gameObject.GetComponent<BirdControl>().hasPlayerOneWon = true;
        }
        else {
            birdInstance.gameObject.GetComponent<BirdControl>().hasPlayerOneWon = false;
        }
    }

    public override void OnEnd()
    {
       
    }

    void QuitState() {
        finished = true;
    }
}
