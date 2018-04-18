﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(MusicInstructions))]
public class GameControlling : MonoBehaviour {

    public AudioClip music;
    public float baseMoveReactionTime;
    public bool gamePaused;

    private Pair<DanceMove, float>[] instructions = new Pair<DanceMove, float>[16];

    static public Skin firstPlayerSkin;
    static public Skin secondPlayerSkin;
    public GameObject[] skinObjects;
    private Skin[] skins;
    public GameObject playerOne;
    public GameObject playerTwo;
    void Start() {
<<<<<<< HEAD
        CreateSkins();
        CreateInstructions();
=======
        gamePaused = false;
        //DanceMove(float rightArm, float leftArm, float rightLeg, float leftLeg, int index)
        DanceMove leftArmUp =          new DanceMove(0f, 2f, -1f, -1f, (int)MusicInstructions.DanceMoveEnum.LeftArmUp);
        DanceMove rightArmUp =         new DanceMove(2f, 0f, -1f, -1f, (int)MusicInstructions.DanceMoveEnum.RightArmUp);
        DanceMove bothArmsUp =         new DanceMove(2f, 2f, -1f, -1f, (int)MusicInstructions.DanceMoveEnum.BothArmsUp);
        DanceMove bothArmsDown =       new DanceMove(0f, 0f, -1f, -1f, (int)MusicInstructions.DanceMoveEnum.BothArmsDown);
        DanceMove splitArmsUp =        new DanceMove(2f, 2f, 2f,  2f, (int)MusicInstructions.DanceMoveEnum.SplitArmsUp);
        DanceMove splitArmsDown =      new DanceMove(0f, 0f, 2f,  2f, (int)MusicInstructions.DanceMoveEnum.SplitArmsDown);
        DanceMove leftArmLeftLegUp =   new DanceMove(1f, 2f, 1f,  2f, (int)MusicInstructions.DanceMoveEnum.LeftArmLeftLegUp);
        DanceMove rightArmRightLegUp = new DanceMove(2f, 1f, 2f,  1f, (int)MusicInstructions.DanceMoveEnum.RightArmRightLegUp);

      //  moveReactionTime = 2f;
        GetComponent<MusicInstructions>().SetMusic(music, instructions);
        instructions[0] = new Pair<DanceMove, float>(bothArmsDown, baseMoveReactionTime);
        instructions[1] = new Pair<DanceMove, float>(leftArmUp, baseMoveReactionTime);
        instructions[2] = new Pair<DanceMove, float>(bothArmsDown, baseMoveReactionTime);
        instructions[3] = new Pair<DanceMove, float>(rightArmUp, baseMoveReactionTime);
        instructions[4] = new Pair<DanceMove, float>(bothArmsDown, baseMoveReactionTime);
        instructions[5] = new Pair<DanceMove, float>(rightArmUp, baseMoveReactionTime);
        instructions[6] = new Pair<DanceMove, float>(bothArmsUp, baseMoveReactionTime);
        instructions[7] = new Pair<DanceMove, float>(leftArmUp, baseMoveReactionTime);
        instructions[8] = new Pair<DanceMove, float>(bothArmsDown, baseMoveReactionTime);
        instructions[9] = new Pair<DanceMove, float>(leftArmUp, baseMoveReactionTime);
        instructions[10] = new Pair<DanceMove, float>(bothArmsDown, baseMoveReactionTime);
        //moveReactionTime = 2.5f;
        instructions[11] = new Pair<DanceMove, float>(leftArmLeftLegUp, baseMoveReactionTime * 2.5f);
        //moveReactionTime = 2f;
        instructions[12] = new Pair<DanceMove, float>(bothArmsUp, baseMoveReactionTime *  2f);
        instructions[13] = new Pair<DanceMove, float>(rightArmRightLegUp, baseMoveReactionTime *2f);
        instructions[14] = new Pair<DanceMove, float>(splitArmsDown, baseMoveReactionTime *2f);
        //moveReactionTime = 1f;
        instructions[15] = new Pair<DanceMove, float>(splitArmsUp, baseMoveReactionTime);

>>>>>>> master
    }

    void Update() {
        //Debug.Log("LeftArm: " + GameObject.FindGameObjectWithTag("LeftArm").GetComponent<LimbMovement>().GetLimbState() + "RightArm: " + GameObject.FindGameObjectWithTag("RightArm").GetComponent<LimbMovement>().GetLimbState());
        //Debug.Log("LeftLeg: " + GameObject.FindGameObjectWithTag("LeftLeg").GetComponent<LimbMovement>().GetLimbState() + "RightLeg: " + GameObject.FindGameObjectWithTag("RightLeg").GetComponent<LimbMovement>().GetLimbState());
        if (Input.GetKey(KeyCode.Alpha1) && Input.GetKey(KeyCode.Alpha2) && Input.GetKey(KeyCode.Alpha3) && Input.GetKey(KeyCode.Alpha4)) {
            PlayerPrefs.DeleteAll();
            Debug.LogWarning("Playerprefs Deleted!");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            changePause();
        }
    }

    public void GameOver() {
        Invoke("QuitToLeaderboard", 5f);
    }
    private void QuitToLeaderboard() {
        int[] temp = new int[10];
        for (int i = temp.Length - 1; i >= 0; i--) {
            temp[i] = PlayerPrefs.GetInt("HighScore" + i.ToString(), (i + 1) * 100);
            PlayerPrefs.SetInt("HighScore" + i.ToString(), temp[i]);
        }
        if (temp[0] < GetComponent<ScoringSystem>().GetFirstPlayerScore() || temp[0] < GetComponent<ScoringSystem>().GetFirstPlayerScore()) {
            if (temp[0] > GetComponent<ScoringSystem>().GetFirstPlayerScore()) {
                NameInput.hasPlayerOneHighscore = false;
            }
            else {
                NameInput.hasPlayerOneHighscore = true;
            }
            if (temp[0] > GetComponent<ScoringSystem>().GetSecondPlayerScore()) {
                NameInput.hasPlayerTwoHighscore = false;
            }
            else {
                NameInput.hasPlayerTwoHighscore = true;
            }
            SceneManager.LoadScene("EnterNameScene");
            NameInput.wasNameEntered = true;
        }
        else {
            SceneManager.LoadScene("LeaderboardScene");
            NameInput.wasNameEntered = false;
        }
    }

<<<<<<< HEAD
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
        GetComponent<MusicInstructions>().SetMusic(music, instructions);
        instructions[0] = new Pair<DanceMove, float>(bothArmsDown, moveReactionTime);
        instructions[1] = new Pair<DanceMove, float>(leftArmUp, moveReactionTime);
        instructions[2] = new Pair<DanceMove, float>(bothArmsDown, moveReactionTime);
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
        instructions[15] = new Pair<DanceMove, float>(splitArmsUp, moveReactionTime);
    }
    
    private void CreateSkins()
    {
        skins = new Skin[skinObjects.Length];
        for(int i = 0; i < skinObjects.Length; i++)
        {
            skins[i] = skinObjects[i].GetComponent<Skin>();
        }
        int firstPlayerIndex = PlayerPrefs.GetInt("FirstPlayerSkin", -1);
        if(firstPlayerIndex == -1)
        {
            PlayerPrefs.SetInt("FirstPlayerSkin", 0);
            firstPlayerIndex = 0;
        }
        int secondPlayerIndex = PlayerPrefs.GetInt("SecondPlayerSkin", -1);
        if (secondPlayerIndex == -1)
        {
            PlayerPrefs.SetInt("SecondPlayerSkin", skins.Length - 1);
            secondPlayerIndex = skins.Length - 1;
        }
        firstPlayerSkin = skins[firstPlayerIndex];
        secondPlayerSkin = skins[secondPlayerIndex];
        playerOne.GetComponent<SkinSetting>().SetSkins();
        playerTwo.GetComponent<SkinSetting>().SetSkins();
=======
   public void changePause ()
    {
        if (gamePaused == false)
        {
            Time.timeScale = 0;
            gamePaused = true;
        } else
        {
            Time.timeScale = 1;
            gamePaused = false;
        }
>>>>>>> master
    }
}