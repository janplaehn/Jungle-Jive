using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MusicInstructions))]
public class GameControlling : MonoBehaviour {
    public AudioClip music;
    private Pair<DanceMove, float>[] instructions = new Pair<DanceMove, float>[9];

    // Use this for initialization
    void Start()
    {
        DanceMove leftArmUp;
        leftArmUp.instructionImageIndex = (int)MusicInstructions.DanceMoveEnum.LeftArmUp;
        leftArmUp.LeftArmPosition = 2f;
        leftArmUp.RightArmPosition = 0f;
        leftArmUp.LeftLegPosition = -1f;
        leftArmUp.RightLegPosition = -1f;
        instructions[0] = new Pair<DanceMove, float>(leftArmUp, 1f);
        DanceMove rightArmUp;
        rightArmUp.instructionImageIndex = (int)MusicInstructions.DanceMoveEnum.RightArmUp;
        rightArmUp.LeftArmPosition = 0f;
        rightArmUp.RightArmPosition = 2f;
        rightArmUp.LeftLegPosition = -1f;
        rightArmUp.RightLegPosition = -1f;
        instructions[1] = new Pair<DanceMove, float>(rightArmUp, 3f);

        DanceMove bothArmsUp;
        bothArmsUp.instructionImageIndex = (int)MusicInstructions.DanceMoveEnum.BothArmsUp;
        bothArmsUp.RightArmPosition = 2f;
        bothArmsUp.LeftArmPosition = 2f;
        bothArmsUp.RightLegPosition = -1f;
        bothArmsUp.LeftLegPosition = -1f;
        instructions[2] = new Pair<DanceMove, float>(bothArmsUp, 5f);

        DanceMove bothArmsDown;
        bothArmsDown.instructionImageIndex = (int)MusicInstructions.DanceMoveEnum.BothArmsDown;
        bothArmsDown.RightArmPosition = 0f;
        bothArmsDown.LeftArmPosition = 0f;
        bothArmsDown.RightLegPosition = -1f;
        bothArmsDown.LeftLegPosition = -1f;
        instructions[3] = new Pair<DanceMove, float>(bothArmsDown, 7f);

        DanceMove splitArmsUp;
        splitArmsUp.instructionImageIndex = (int)MusicInstructions.DanceMoveEnum.SplitArmsUp;
        splitArmsUp.RightArmPosition = 2f;
        splitArmsUp.LeftArmPosition = 2f;
        splitArmsUp.RightLegPosition = 2f;
        splitArmsUp.LeftLegPosition = 2f;
        instructions[4] = new Pair<DanceMove, float>(splitArmsUp, 9f);

        instructions[5] = new Pair<DanceMove, float>(leftArmUp, 11f);

        instructions[6] = new Pair<DanceMove, float>(rightArmUp, 13f);

        instructions[7] = new Pair<DanceMove, float>(bothArmsUp, 15f);

        DanceMove endMove;
        endMove.instructionImageIndex = (int)MusicInstructions.DanceMoveEnum.BothArmsUp;
        endMove.LeftArmPosition = -1f;
        endMove.RightArmPosition = -1f;
        endMove.LeftLegPosition = -1f;
        endMove.RightLegPosition = -1f;
        instructions[8] = new Pair<DanceMove, float>(endMove, 17f);
        GetComponent<MusicInstructions>().SetMusic(music, instructions);

    }
    void Update()
    {

        Debug.Log("LeftArm: " + GameObject.FindGameObjectWithTag("LeftArm").GetComponent<LimbMovement>().GetLimbState() + "RightArm: " + GameObject.FindGameObjectWithTag("RightArm").GetComponent<LimbMovement>().GetLimbState());
        //Debug.Log("LeftLeg: " + GameObject.FindGameObjectWithTag("LeftLeg").GetComponent<LimbMovement>().GetLimbState() + "RightLeg: " + GameObject.FindGameObjectWithTag("RightLeg").GetComponent<LimbMovement>().GetLimbState());
    }

    public void GameOver()
    {
        Invoke("GoToLeaderBoard", 2f);
    }

    private void GoToLeaderBoard()
    {
        SceneManager.LoadScene("ClementScene");
    }
}
