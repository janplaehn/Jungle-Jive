using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlling : MonoBehaviour {
    public GameState stateManager;
    public AudioClip music;
    public float animationSpeed = 1;
    public float moveReactionTime;
    private bool isPaused;



    void Start() {
        isPaused = false;
        CreateInstructions();
        if (GameObject.Find("MusicManager")) {
            GameObject.Find("MusicManager").GetComponent<MusicManagement>().Play("DanceMusic");
        }
    }

    void Update() {
        //Debug.Log("LeftArm: " + GameObject.FindGameObjectWithTag("LeftArm").GetComponent<LimbMovement>().GetLimbState() + "RightArm: " + GameObject.FindGameObjectWithTag("RightArm").GetComponent<LimbMovement>().GetLimbState());
        //Debug.Log("LeftLeg: " + GameObject.FindGameObjectWithTag("LeftLeg").GetComponent<LimbMovement>().GetLimbState() + "RightLeg: " + GameObject.FindGameObjectWithTag("RightLeg").GetComponent<LimbMovement>().GetLimbState());

    }

    public void GameOver() {
        GameObject.Find("WinCanvas").GetComponent<WinCanvasController>().ShowWinText();
        foreach (GameObject face in GameObject.FindGameObjectsWithTag("FeedbackFace1")) {
            if (face.GetComponent<AudienceFeedbackController>())
                face.GetComponent<AudienceFeedbackController>().BeHappy();
        }
        foreach (GameObject face in GameObject.FindGameObjectsWithTag("FeedbackFace2")) {
            if (face.GetComponent<AudienceFeedbackController>())
                face.GetComponent<AudienceFeedbackController>().BeHappy();
        }
        if (GameObject.Find("MusicManager")) {
            GameObject.Find("MusicManager").GetComponent<MusicManagement>().Stop("DanceMusic");
            GameObject.Find("MusicManager").GetComponent<MusicManagement>().Play("MenuMusic");
        }
        Invoke("QuitToLeaderboard", 5f);
    }

    private void QuitToLeaderboard() {
        SceneManager.LoadScene("EnterNameScene");
    }

    void CreateInstructions()
    {
        //DanceMove leftArmUp = new DanceMove((int)LimbState.Up, (int)LimbState.Up, -(int)LimbState.None, (int)LimbState.None, (int)MusicInstructions.DanceMoveEnum.LeftArmUp);
        //DanceMove rightArmUp = new DanceMove((int)LimbState.Up, (int)LimbState.Down, -(int)LimbState.Middle, -(int)LimbState.Middle, (int)MusicInstructions.DanceMoveEnum.RightArmUp);
        //DanceMove bothArmsUp = new DanceMove((int)LimbState.Up, (int)LimbState.Up, -(int)LimbState.Middle, -(int)LimbState.Middle, (int)MusicInstructions.DanceMoveEnum.BothArmsUp);
        //DanceMove bothArmsDown = new DanceMove((int)LimbState.Down, (int)LimbState.Down, -(int)LimbState.Middle, -(int)LimbState.Middle, (int)MusicInstructions.DanceMoveEnum.BothArmsDown);
        //DanceMove splitArmsUp = new DanceMove((int)LimbState.Up, (int)LimbState.Up, (int)LimbState.Up, (int)LimbState.Up, (int)MusicInstructions.DanceMoveEnum.SplitArmsUp);
        //DanceMove splitArmsDown = new DanceMove((int)LimbState.Down, (int)LimbState.Down, (int)LimbState.Up, (int)LimbState.Up, (int)MusicInstructions.DanceMoveEnum.SplitArmsDown);
        //DanceMove leftArmLeftLegUp = new DanceMove((int)LimbState.Middle, (int)LimbState.Up, (int)LimbState.Middle, (int)LimbState.Up, (int)MusicInstructions.DanceMoveEnum.LeftArmLeftLegUp);
        //DanceMove rightArmRightLegUp = new DanceMove((int)LimbState.Up, (int)LimbState.Middle, (int)LimbState.Up, (int)LimbState.Middle, (int)MusicInstructions.DanceMoveEnum.RightArmRightLegUp);
        //DanceMove leftArmleftLegAside = new DanceMove((int)LimbState.Middle, (int)LimbState.Up, (int)LimbState.Middle, (int)LimbState.Up, (int)MusicInstructions.DanceMoveEnum.LeftArmleftLegAside);
        //DanceMove rightArmrightLegAside = new DanceMove((int)LimbState.Up, (int)LimbState.Middle, (int)LimbState.Up, (int)LimbState.Middle, (int)MusicInstructions.DanceMoveEnum.RightArmrightLegAside);
        //DanceMove leftArmRightLegSlash = new DanceMove((int)LimbState.Middle, (int)LimbState.Up, (int)LimbState.Middle, (int)LimbState.Down, (int)MusicInstructions.DanceMoveEnum.LeftArmRightLegSlash);
        //DanceMove rightArmLeftLegSlash = new DanceMove((int)LimbState.Up, (int)LimbState.Middle, (int)LimbState.Down, (int)LimbState.Middle, (int)MusicInstructions.DanceMoveEnum.rightArmLeftLegSlash);

        //  moveReactionTime = 2f;
        //instructions[0] = new Pair<DanceMove, float>(bothArmsDown, moveReactionTime);
        //instructions[1] = new Pair<DanceMove, float>(leftArmUp, moveReactionTime);
        //freestyle.GetComponent<Freestyle>().SetActiveFor (5);

        /* instructions[2] = new Pair<DanceMove, float>(bothArmsDown, moveReactionTime);
         instructions[3] = new Pair<DanceMove, float>(rightArmUp, moveReactionTime);
         instructions[4] = new Pair<DanceMove, float>(bothArmsDown, moveReactionTime);
         instructions[5] = new Pair<DanceMove, float>(rightArmUp, moveReactionTime);
         instructions[6] = new Pair<DanceMove, float>(bothArmsUp, moveReactionTime);
         instructions[7] = new Pair<DanceMove, float>(leftArmUp, moveReactionTime);
         instructions[8] = new Pair<DanceMove, float>(bothArmsDown, moveReactionTime);
         instructions[9] = new Pair<DanceMove, float>(leftArmUp, moveReactionTime);
         instructions[10] = new Pair<DanceMove, float>(bothArmsDown, moveReactionTime);
         //moveReactionTime = 2.5f;
         instructions[11] = new Pair<DanceMove, float>(leftArmLeftLegUp, moveReactionTime);
         //moveReactionTime = 2f;
         instructions[12] = new Pair<DanceMove, float>(bothArmsUp, moveReactionTime);
         instructions[13] = new Pair<DanceMove, float>(rightArmRightLegUp, moveReactionTime);
         instructions[14] = new Pair<DanceMove, float>(splitArmsDown, moveReactionTime);
         //moveReactionTime = 1f;
         instructions[15] = new Pair<DanceMove, float>(splitArmsUp, moveReactionTime);*/
        //MusicInstruction1.GetComponent<MusicInstructions>().SetMusic(music, instructions);

    }
    

    


}