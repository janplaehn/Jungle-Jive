﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMiniGame : State {

    public Vector3 birdSpawnPosition;
    public float miniGameTimer = 6f;
    public GameObject shakeText;
    public Transform bird;

    private GameObject canvas;
    private float playerOneScore;
    private float playerTwoScore;
    private InputCheck input;
    private bool finished = false;
    private GameObject birdInstance;

    private void Start() {
        shakeText.SetActive(false);

    }

    public override void OnStart() {
        shakeText.SetActive(true);
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

    public void ResetPositions(string playerTag) {
        StartCoroutine(Banana.ResetPositions(playerTag, GameObject.Find("bananaSmashCollider")));
        StartCoroutine(Banana.FlyOff(playerTag));
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
        shakeText.SetActive(false);
    }

    public override void OnEnd()
    {
        Debug.Log(playerOneScore + " + " + playerTwoScore);
        shakeText.SetActive(false);
    }

    void QuitState() {
        finished = true;
    }
}
