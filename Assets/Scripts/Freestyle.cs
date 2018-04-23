using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freestyle : MonoBehaviour {
    public List<DanceMove> recentMoves;
    [SerializeField] private bool isPlayerOne;
    private ScoringSystem scoringSystem;
    private InputCheck inputCheck;
    private DanceMove lastMove;
    // Use this for initialization
    void Start () {
        recentMoves = new List<DanceMove>();
        inputCheck = GameObject.FindGameObjectWithTag("GameController").GetComponent<InputCheck>();
        scoringSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoringSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        DanceMove tempMove = inputCheck.getCurrentMove(isPlayerOne);

	}
}
