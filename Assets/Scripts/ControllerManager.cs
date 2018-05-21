using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour {
    public static float player1LeftArm;
    public static float player1RightArm;
    public static float player1LeftLeg;
    public static float player1RightLeg;
    public static float player2LeftArm;
    public static float player2RightArm;
    public static float player2LeftLeg;
    public static float player2RightLeg;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        player1LeftArm = Input.GetAxis("LeftStickVertical");
        player1RightArm = Input.GetAxis("RightStickVertical");
        player1LeftLeg = Input.GetAxis("LeftStickHorizontal");
        player1RightLeg = Input.GetAxis("RightStickHorizontal");

        player2LeftArm = Input.GetAxis("P2LeftStickVertical");
        player2RightArm = Input.GetAxis("P2RightStickVertical");
        player2LeftLeg = Input.GetAxis("P2LeftStickHorizontal");
        player2RightLeg = Input.GetAxis("P2RightStickHorizontal");
    }

}
