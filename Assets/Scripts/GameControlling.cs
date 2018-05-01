using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(MusicInstructions))]
public class GameControlling : MonoBehaviour {
    enum LimbState
    {
        Down = 0,
        Middle = 1,
        Up = 2,
        None = -1,
    }
    public AudioClip music;
    public float animationSpeed = 1;
    public float moveReactionTime;
    private Pair<DanceMove, float>[] instructions = new Pair<DanceMove, float>[16];
    private bool isPaused;
    void Start() {
        isPaused = false;
        CreateInstructions();
    }

    void Update() {
        //Debug.Log("LeftArm: " + GameObject.FindGameObjectWithTag("LeftArm").GetComponent<LimbMovement>().GetLimbState() + "RightArm: " + GameObject.FindGameObjectWithTag("RightArm").GetComponent<LimbMovement>().GetLimbState());
        //Debug.Log("LeftLeg: " + GameObject.FindGameObjectWithTag("LeftLeg").GetComponent<LimbMovement>().GetLimbState() + "RightLeg: " + GameObject.FindGameObjectWithTag("RightLeg").GetComponent<LimbMovement>().GetLimbState());
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            changePauseState();
        }
    }

    public void GameOver() {
        GameObject.Find("WinCanvas").GetComponent<WinCanvasController>().ShowWinText();
        foreach (GameObject face in GameObject.FindGameObjectsWithTag("FeedbackFace1")) {
            face.GetComponent<AudienceFeedbackController>().BeHappy();
        }
        foreach (GameObject face in GameObject.FindGameObjectsWithTag("FeedbackFace2")) {
            face.GetComponent<AudienceFeedbackController>().BeHappy();
        }
        Invoke("QuitToLeaderboard", 5f);
    }

    private void QuitToLeaderboard() {
        SceneManager.LoadScene("EnterNameScene");
    }

    void CreateInstructions()
    {
        //DanceMove(float rightArm, float leftArm, float rightLeg, float leftLeg, int index)
        DanceMove leftArmUp = new DanceMove((int)LimbState.Up, (int)LimbState.Up, -(int)LimbState.None, (int)LimbState.None, (int)MusicInstructions.DanceMoveEnum.LeftArmUp);
        DanceMove rightArmUp = new DanceMove((int)LimbState.Up, (int)LimbState.Down, -(int)LimbState.Middle, -(int)LimbState.Middle, (int)MusicInstructions.DanceMoveEnum.RightArmUp);
        DanceMove bothArmsUp = new DanceMove((int)LimbState.Up, (int)LimbState.Up, -(int)LimbState.Middle, -(int)LimbState.Middle, (int)MusicInstructions.DanceMoveEnum.BothArmsUp);
        DanceMove bothArmsDown = new DanceMove((int)LimbState.Down, (int)LimbState.Down, -(int)LimbState.Middle, -(int)LimbState.Middle, (int)MusicInstructions.DanceMoveEnum.BothArmsDown);
        DanceMove splitArmsUp = new DanceMove((int)LimbState.Up, (int)LimbState.Up, (int)LimbState.Up, (int)LimbState.Up, (int)MusicInstructions.DanceMoveEnum.SplitArmsUp);
        DanceMove splitArmsDown = new DanceMove((int)LimbState.Down, (int)LimbState.Down, (int)LimbState.Up, (int)LimbState.Up, (int)MusicInstructions.DanceMoveEnum.SplitArmsDown);
        DanceMove leftArmLeftLegUp = new DanceMove((int)LimbState.Middle, (int)LimbState.Up, (int)LimbState.Middle, (int)LimbState.Up, (int)MusicInstructions.DanceMoveEnum.LeftArmLeftLegUp);
        DanceMove rightArmRightLegUp = new DanceMove((int)LimbState.Up, (int)LimbState.Middle, (int)LimbState.Up, (int)LimbState.Middle, (int)MusicInstructions.DanceMoveEnum.RightArmRightLegUp);
        //DanceMove leftArmleftLegAside = new DanceMove((int)LimbState.Middle, (int)LimbState.Up, (int)LimbState.Middle, (int)LimbState.Up, (int)MusicInstructions.DanceMoveEnum.LeftArmleftLegAside);
        //DanceMove rightArmrightLegAside = new DanceMove((int)LimbState.Up, (int)LimbState.Middle, (int)LimbState.Up, (int)LimbState.Middle, (int)MusicInstructions.DanceMoveEnum.RightArmrightLegAside);
        //DanceMove leftArmRightLegSlash = new DanceMove((int)LimbState.Middle, (int)LimbState.Up, (int)LimbState.Middle, (int)LimbState.Down, (int)MusicInstructions.DanceMoveEnum.LeftArmRightLegSlash);
        //DanceMove rightArmLeftLegSlash = new DanceMove((int)LimbState.Up, (int)LimbState.Middle, (int)LimbState.Down, (int)LimbState.Middle, (int)MusicInstructions.DanceMoveEnum.rightArmLeftLegSlash);


        //  moveReactionTime = 2f;
        GetComponent<MusicInstructions>().SetMusic(music, instructions);
        instructions[0] = new Pair<DanceMove, float>(bothArmsDown, moveReactionTime);
        instructions[1] = new Pair<DanceMove, float>(leftArmUp, moveReactionTime);
        instructions[2] = new Pair<DanceMove, float>(bothArmsDown, moveReactionTime);
        instructions[3] = new Pair<DanceMove, float>(rightArmUp, moveReactionTime * 0.65f);
        instructions[4] = new Pair<DanceMove, float>(leftArmUp, moveReactionTime * 0.65f);
        instructions[5] = new Pair<DanceMove, float>(rightArmUp, moveReactionTime * 0.65f);
        instructions[6] = new Pair<DanceMove, float>(bothArmsUp, moveReactionTime * 0.65f);
        instructions[7] = new Pair<DanceMove, float>(bothArmsUp, moveReactionTime);
        instructions[8] = new Pair<DanceMove, float>(leftArmUp, moveReactionTime * 0.65f);
        instructions[9] = new Pair<DanceMove, float>(rightArmUp, moveReactionTime * 0.65f);
        instructions[10] = new Pair<DanceMove, float>(bothArmsUp, moveReactionTime * 0.65f);
        instructions[11] = new Pair<DanceMove, float>(leftArmLeftLegUp, moveReactionTime);
        instructions[12] = new Pair<DanceMove, float>(bothArmsUp, moveReactionTime * 0.65f);
        instructions[13] = new Pair<DanceMove, float>(rightArmRightLegUp, moveReactionTime);
        instructions[14] = new Pair<DanceMove, float>(splitArmsDown, moveReactionTime * 0.65f);
        instructions[15] = new Pair<DanceMove, float>(splitArmsUp, moveReactionTime * 0.5f);
    }
    
    

    public void changePauseState()
    {
        if (isPaused == false)
        {
            Time.timeScale = 0;
            isPaused = true;
            GetComponent<MusicInstructions>().isPaused = true;
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
            GetComponent<MusicInstructions>().isPaused = false;
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