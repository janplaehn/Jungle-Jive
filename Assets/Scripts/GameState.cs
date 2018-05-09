using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    int stateIndex = 0;
    public List<State> states;

    bool isPaused = false;
    bool started = true;
    bool finished = false;
	void Start()
    {
        states[stateIndex].OnStart();
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            changePauseState();
        }
        if (!started || finished || isPaused) return;
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

    public void changePauseState()
    {
        if (isPaused == false)
        {
            Time.timeScale = 0;
            isPaused = true;
            GetComponentInChildren<MusicInstructions>().isPaused = true;
            LimbMovement[] limbMovements = GameObject.FindGameObjectWithTag("Player1").GetComponentsInChildren<LimbMovement>();
            foreach (LimbMovement i in limbMovements)
            {
                i.isPaused = true;
            }
            LimbMovement[] limbMovements2 = GameObject.FindGameObjectWithTag("Player2").GetComponentsInChildren<LimbMovement>();
            foreach (LimbMovement i in limbMovements2)
            {
                i.isPaused = true;
            }
            FindObjectOfType<AudioSource>().Pause();
        }
        else
        {
            Time.timeScale = 1;
            isPaused = false;
            GetComponentInChildren<MusicInstructions>().isPaused = false;
            LimbMovement[] limbMovements = GameObject.FindGameObjectWithTag("Player1").GetComponentsInChildren<LimbMovement>();
            foreach (LimbMovement i in limbMovements)
            {
                i.isPaused = false;
            }
            LimbMovement[] limbMovements2 = GameObject.FindGameObjectWithTag("Player2").GetComponentsInChildren<LimbMovement>();
            foreach (LimbMovement i in limbMovements2)
            {
                i.isPaused = false;
            }
            FindObjectOfType<AudioSource>().UnPause();

        }
    }
}
