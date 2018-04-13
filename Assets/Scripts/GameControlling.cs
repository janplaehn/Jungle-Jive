using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(MusicInstructions))]
public class GameControlling : MonoBehaviour {
    public AudioClip music;
    private Pair<DanceMove, float>[] instructions = new Pair<DanceMove, float>[19];
    // Use this for initialization
    void Start() {
        DanceMove leftArmUp;
        leftArmUp.instructionImageIndex = (int)MusicInstructions.DanceMoveEnum.LeftArmUp;
        leftArmUp.LeftArmPosition = 2f;
        leftArmUp.RightArmPosition = 0f;
        leftArmUp.LeftLegPosition = -1f;
        leftArmUp.RightLegPosition = -1f;
        DanceMove rightArmUp;
        rightArmUp.instructionImageIndex = (int)MusicInstructions.DanceMoveEnum.RightArmUp;
        rightArmUp.LeftArmPosition = 0f;
        rightArmUp.RightArmPosition = 2f;
        rightArmUp.LeftLegPosition = -1f;
        rightArmUp.RightLegPosition = -1f;
        DanceMove bothArmsUp;
        bothArmsUp.instructionImageIndex = (int)MusicInstructions.DanceMoveEnum.BothArmsUp;
        bothArmsUp.RightArmPosition = 2f;
        bothArmsUp.LeftArmPosition = 2f;
        bothArmsUp.RightLegPosition = -1f;
        bothArmsUp.LeftLegPosition = -1f;
        DanceMove bothArmsDown;
        bothArmsDown.instructionImageIndex = (int)MusicInstructions.DanceMoveEnum.BothArmsDown;
        bothArmsDown.RightArmPosition = 0f;
        bothArmsDown.LeftArmPosition = 0f;
        bothArmsDown.RightLegPosition = -1f;
        bothArmsDown.LeftLegPosition = -1f;
        DanceMove splitArmsUp;
        splitArmsUp.instructionImageIndex = (int)MusicInstructions.DanceMoveEnum.SplitArmsUp;
        splitArmsUp.RightArmPosition = 2f;
        splitArmsUp.LeftArmPosition = 2f;
        splitArmsUp.RightLegPosition = 2f;
        splitArmsUp.LeftLegPosition = 2f;
        DanceMove splitArmsDown;
        splitArmsDown.instructionImageIndex = (int)MusicInstructions.DanceMoveEnum.SplitArmsDown;
        splitArmsDown.RightArmPosition = 0f;
        splitArmsDown.LeftArmPosition = 0f;
        splitArmsDown.RightLegPosition = 2f;
        splitArmsDown.LeftLegPosition = 2f;
        DanceMove leftArmLeftLegUp;
        leftArmLeftLegUp.instructionImageIndex = (int)MusicInstructions.DanceMoveEnum.LeftArmLeftLegUp;
        leftArmLeftLegUp.RightArmPosition = 1f;
        leftArmLeftLegUp.LeftArmPosition = 2f;
        leftArmLeftLegUp.RightLegPosition = 2f;
        leftArmLeftLegUp.LeftLegPosition = 0f;   /// should it be 0f or -1f? Not sure - Krzesimir
        DanceMove rightArmRightLegUp;
        rightArmRightLegUp.instructionImageIndex = (int)MusicInstructions.DanceMoveEnum.RightArmRightLegUp;
        rightArmRightLegUp.RightArmPosition = 1f;
        rightArmRightLegUp.LeftArmPosition = 2f;
        rightArmRightLegUp.RightLegPosition = 2f;
        rightArmRightLegUp.LeftLegPosition = 0f;   /// should it be 0f or -1f? Not sure - Krzesimir
        DanceMove endMove;
        endMove.instructionImageIndex = (int)MusicInstructions.DanceMoveEnum.SplitArmsDown;
        endMove.LeftArmPosition = -1f;
        endMove.RightArmPosition = -1f;
        endMove.LeftLegPosition = -1f;
        endMove.RightLegPosition = -1f;
        GetComponent<MusicInstructions>().SetMusic(music, instructions);
        instructions[0] = new Pair<DanceMove, float>(bothArmsUp, 1f);
        instructions[1] = new Pair<DanceMove, float>(bothArmsDown, 3f);
        instructions[2] = new Pair<DanceMove, float>(leftArmUp, 5f);
        instructions[3] = new Pair<DanceMove, float>(rightArmUp, 7f);
        instructions[4] = new Pair<DanceMove, float>(bothArmsUp, 9f);
        instructions[5] = new Pair<DanceMove, float>(leftArmUp, 11f);
        instructions[6] = new Pair<DanceMove, float>(rightArmUp, 13f);
        instructions[7] = new Pair<DanceMove, float>(bothArmsUp, 15f);
        instructions[8] = new Pair<DanceMove, float>(bothArmsDown, 17f);
        instructions[9] = new Pair<DanceMove, float>(leftArmUp, 19f);
        instructions[10] = new Pair<DanceMove, float>(leftArmLeftLegUp, 21f);
        instructions[11] = new Pair<DanceMove, float>(leftArmUp, 23f);
        instructions[12] = new Pair<DanceMove, float>(bothArmsUp, 25f);
        instructions[13] = new Pair<DanceMove, float>(rightArmRightLegUp, 27f);
        instructions[14] = new Pair<DanceMove, float>(rightArmUp, 29f);
        instructions[15] = new Pair<DanceMove, float>(bothArmsUp, 31f);
        instructions[16] = new Pair<DanceMove, float>(splitArmsUp, 33f);
        instructions[17] = new Pair<DanceMove, float>(splitArmsDown, 35f);
        instructions[18] = new Pair<DanceMove, float>(endMove, 37f);
    }
    void Update() {
        //Debug.Log("LeftArm: " + GameObject.FindGameObjectWithTag("LeftArm").GetComponent<LimbMovement>().GetLimbState() + "RightArm: " + GameObject.FindGameObjectWithTag("RightArm").GetComponent<LimbMovement>().GetLimbState());
        //Debug.Log("LeftLeg: " + GameObject.FindGameObjectWithTag("LeftLeg").GetComponent<LimbMovement>().GetLimbState() + "RightLeg: " + GameObject.FindGameObjectWithTag("RightLeg").GetComponent<LimbMovement>().GetLimbState());
    }

    public void GameOver() {
        Invoke("QuitToLeaderboard", 5f);
    }
    private void QuitToLeaderboard() {
        SceneManager.LoadScene("ClementScene");
    }
}