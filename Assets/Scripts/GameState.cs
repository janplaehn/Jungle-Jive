using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    int stateIndex = 0;
    List<GameObject> states = new List<GameObject>();

    bool started = false;
    bool finished = false;
	
	// Update is called once per frame
	void Update () {
        if (!started || finished) return;
        if(states[stateIndex].GetComponent<State>().OnUpdate() == false) {
            states[stateIndex].GetComponent<State>().OnEnd();
            NextState();
        }
	}

    public void AddState (GameObject stateAdded)
    {
        states.Add(stateAdded);
        if (states.Count == 1) states[0].GetComponent<State>().OnStart();
        started = true;
        finished = false;
    }
    

    public GameObject GetCurrentState ()
    {
        return states[stateIndex];
    }

    private void NextState()
    {
        stateIndex += 1;

        if (stateIndex > states.Count - 1)
        {
            finished = true;
            GetComponent<GameControlling>().GameOver();
        } else
        {
            states[stateIndex].GetComponent<State>().OnStart();
        }
    }

}
