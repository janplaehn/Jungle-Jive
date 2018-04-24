using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    int stateIndex = 0;
    List<Pair<GameObject, GameStates>> states;
    GameStates currentStateType;
    public enum GameStates{
        MusicInstruction,
        Freestyle,
    }

    bool started = false;
    bool finished = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!started || finished) return;
        switch (states[stateIndex].secondValue)
        {
            case GameStates.MusicInstruction:
                states[stateIndex].firstValue.GetComponent<MusicInstructions>().OnUpdate();
                if (states[stateIndex].firstValue.GetComponent<MusicInstructions>().stateFinished == true) NextState();
                break;
            default:
                break;
        }
	}

    public void AddState (GameObject stateAdded, GameStates gameStateAdded)
    {
        Pair<GameObject, GameStates> temp = new Pair<GameObject, GameStates>(stateAdded, gameStateAdded);
        states.Add(temp);
        started = true;
        finished = false;
    }

    public GameObject GetCurrentState ()
    {
        return states[stateIndex].firstValue;
    }

    private void NextState()
    {
        stateIndex += 1;
        if (stateIndex > states.Count - 1)
        {
            finished = true;
            GetComponent<GameControlling>().GameOver();
        }
    }

}
