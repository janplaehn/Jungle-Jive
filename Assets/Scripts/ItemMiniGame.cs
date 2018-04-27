using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMiniGame : MonoBehaviour {

    public float miniGameTimer = 6f;
    public GameObject miniGameInstruction;
    private GameObject playerOne;
    private GameObject playerTwo;
    private float playerOneScore;
    private float playerTwoScore;
    private InputCheck input;
    private bool finished = false;

    // Use this for initialization
    public void OnStart () {
        playerOne = GameObject.FindGameObjectWithTag("Player1");
        playerTwo = GameObject.FindGameObjectWithTag("Player2");
        input = GameObject.FindGameObjectWithTag("GameController").GetComponent<InputCheck>();
        Invoke("QuitState", miniGameTimer);
    }

    // Update is called once per frame
    public bool OnUpdate () {
        playerOneScore += input.GetShakingUp(InputCheck.Players.PlayerOne);
        playerTwoScore += input.GetShakingUp(InputCheck.Players.PlayerTwo);
        if(finished == true)
        {
            return false;
        }
        return true;
    }

    private void QuitState()
    {
        finished = true;
        //make the toucan go to the player who has the most score
    }
}
