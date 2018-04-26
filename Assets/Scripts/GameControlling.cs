using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlling : MonoBehaviour {
    public GameObject MusicInstruction1;
    public GameObject freestyle;
    public GameState stateManager;
    public AudioClip music;
    public float animationSpeed = 1;
    public float moveReactionTime;
    private Pair<DanceMove, float>[] instructions = new Pair<DanceMove, float>[2];
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
            if (face.GetComponent<AudienceFeedbackController>())
                face.GetComponent<AudienceFeedbackController>().BeHappy();
        }
        foreach (GameObject face in GameObject.FindGameObjectsWithTag("FeedbackFace2")) {
            if (face.GetComponent<AudienceFeedbackController>())
                face.GetComponent<AudienceFeedbackController>().BeHappy();
        }
        Invoke("QuitToLeaderboard", 5f);
    }

    private void QuitToLeaderboard() {
        if (GameObject.Find("MusicManager")) {
            GameObject.Find("MusicManager").GetComponent<MusicManagement>().Play("MenuMusic");
        }
        SceneManager.LoadScene("EnterNameScene");
    }

    void CreateInstructions()
    {
        //DanceMove(float rightArm, float leftArm, float rightLeg, float leftLeg, int index)
        DanceMove leftArmUp = new DanceMove(0f, 2f, -1f, -1f, (int)MusicInstructions.DanceMoveEnum.LeftArmUp);
        DanceMove rightArmUp = new DanceMove(2f, 0f, -1f, -1f, (int)MusicInstructions.DanceMoveEnum.RightArmUp);
        DanceMove bothArmsUp = new DanceMove(2f, 2f, -1f, -1f, (int)MusicInstructions.DanceMoveEnum.BothArmsUp);
        DanceMove bothArmsDown = new DanceMove(0f, 0f, -1f, -1f, (int)MusicInstructions.DanceMoveEnum.BothArmsDown);
        DanceMove splitArmsUp = new DanceMove(2f, 2f, 2f, 2f, (int)MusicInstructions.DanceMoveEnum.SplitArmsUp);
        DanceMove splitArmsDown = new DanceMove(0f, 0f, 2f, 2f, (int)MusicInstructions.DanceMoveEnum.SplitArmsDown);
        DanceMove leftArmLeftLegUp = new DanceMove(1f, 2f, 1f, 2f, (int)MusicInstructions.DanceMoveEnum.LeftArmLeftLegUp);
        DanceMove rightArmRightLegUp = new DanceMove(2f, 1f, 2f, 1f, (int)MusicInstructions.DanceMoveEnum.RightArmRightLegUp);

        //  moveReactionTime = 2f;
        instructions[0] = new Pair<DanceMove, float>(bothArmsDown, moveReactionTime);
        instructions[1] = new Pair<DanceMove, float>(leftArmUp, moveReactionTime);
        freestyle.GetComponent<Freestyle>().SetActiveAt(0, 10);
        /*
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
<<<<<<< HEAD
        instructions[14] = new Pair<DanceMove, float>(splitArmsDown, moveReactionTime * 0.65f);
        instructions[15] = new Pair<DanceMove, float>(splitArmsUp, moveReactionTime * 0.5f);
=======
        instructions[14] = new Pair<DanceMove, float>(splitArmsDown, moveReactionTime);
        //moveReactionTime = 1f;
        instructions[15] = new Pair<DanceMove, float>(splitArmsUp, moveReactionTime);
        */
        MusicInstruction1.GetComponent<MusicInstructions>().SetMusic(music, instructions);
        stateManager.AddState(MusicInstruction1, GameState.GameStates.MusicInstruction);
        stateManager.AddState(freestyle, GameState.GameStates.Freestyle);

>>>>>>> 87da9f9097aa0161f4d011557f30dfe4e124d926
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