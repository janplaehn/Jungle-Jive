using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMiniGame : MonoBehaviour {
    public float introTime = 0;
    private bool initialized = false;
    private bool intro = true;
    private bool finished = false;
    private int firstPlayerScore = 0;
    private int secondPlayerScore = 0;
    private GameObject firstPlayer;
    private GameObject secondPlayer;
    private InputCheck inputCheck;


    public bool OnUpdate()
    {
        //instead of doing this whole "initialize" thing, we could just call an "onStart" function in the GameState script whenever entering a new state.
        if(initialized == false)
        {
            firstPlayer = GameObject.FindGameObjectWithTag("Player1");
            Invoke("StartMiniGame", introTime);
        }
        if(intro == false)
        {
            
        }
        return true;
    }

    private void StartMiniGame()
    {
        intro = false;
        inputCheck = GameObject.FindGameObjectWithTag("GameController").GetComponent<InputCheck>();
        //give feedback to the player that the minigame has started, aka "SHAKE YOUR HANDS UP" or something of the sort
    }
}
