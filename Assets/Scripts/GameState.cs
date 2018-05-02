using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    int stateIndex = 0;
    public List<State> states;

    bool started = false;
    bool finished = false;
	
	// Update is called once per frame
	void Update () {
        if (!started || finished) return;
        if(states[stateIndex].OnUpdate() == false) {
            states[stateIndex].OnEnd();
            NextState();
        }
	}

    public void AddState(GameObject gameObjectAdded)
    {
        AddState(gameObject.GetComponent<State>());
    }

    public void AddState (State stateAdded)
    {
        if (stateAdded == null) return;
        states.Add(stateAdded);
        if (states.Count == 1) states[0].GetComponent<State>().OnStart();
        started = true;
        finished = false;
    }
    

    public State GetCurrentState ()
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
            states[stateIndex].OnStart();
        }
    }

}
