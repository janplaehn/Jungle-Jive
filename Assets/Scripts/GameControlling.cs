using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MusicInstructions))]
public class GameControlling : MonoBehaviour {
    public AudioClip music;
    private Pair<DanceMove, float>[] instructions = new Pair<DanceMove, float>[3];
    // Use this for initialization
    void Start()
    {
        DanceMove leftArmUp;
        leftArmUp.instructionImageIndex = (int)MusicInstructions.DanceMoveEnum.LeftArmUp;
        leftArmUp.LeftArmPosition = 2f;
        leftArmUp.LeftLegPosition = -1f;
        leftArmUp.RightArmPosition = 0f;
        leftArmUp.RightLegPosition = -1f;
        instructions[0] = new Pair<DanceMove, float>(leftArmUp, 1f);
        DanceMove rightArmUp;
        rightArmUp.instructionImageIndex = (int)MusicInstructions.DanceMoveEnum.RightArmUp;
        rightArmUp.LeftArmPosition = 0f;
        rightArmUp.LeftLegPosition = -1f;
        rightArmUp.RightArmPosition = 2f;
        rightArmUp.RightLegPosition = -1f;
        instructions[1] = new Pair<DanceMove, float>(rightArmUp, 3f);
        DanceMove endMove;
        endMove.instructionImageIndex = (int)MusicInstructions.DanceMoveEnum.BothArmsUp;
        endMove.LeftArmPosition = -1f;
        endMove.LeftLegPosition = -1f;
        endMove.RightArmPosition = -1f;
        endMove.RightLegPosition = -1f;
        instructions[2] = new Pair<DanceMove, float>(endMove, 5f);
        GetComponent<MusicInstructions>().SetMusic(music, instructions);
    }
    void Update()
    {

        Debug.Log("LeftArm: " + GameObject.FindGameObjectWithTag("LeftArm").GetComponent<LimbMovement>().GetLimbState() + "RightArm: " + GameObject.FindGameObjectWithTag("RightArm").GetComponent<LimbMovement>().GetLimbState());
        //Debug.Log("LeftLeg: " + GameObject.FindGameObjectWithTag("LeftLeg").GetComponent<LimbMovement>().GetLimbState() + "RightLeg: " + GameObject.FindGameObjectWithTag("RightLeg").GetComponent<LimbMovement>().GetLimbState());
    }
}
