using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSetting : MonoBehaviour {
    [HideInInspector] public List<GameObject> playerOnePrefabs = new List<GameObject>();
    [HideInInspector] public List<GameObject> playerTwoPrefabs = new List<GameObject>();
    private int playerOneIndex;
    private int playerTwoIndex;

    [HideInInspector] public GameObject playerOne;
    [HideInInspector] public GameObject playerTwo;

    public GameObject playerOneSpawn;
    public GameObject playerTwoSpawn;

    public bool showSecondPlayer;
    public bool isInMenu;

    void Start() {
        //PlayerPrefs.DeleteAll();
        GetSkins();
        playerOneIndex = PlayerPrefs.GetInt("FirstPlayerSkin", 0);
        PlayerPrefs.SetInt("FirstPlayerSkin", playerOneIndex);
        playerTwoIndex = PlayerPrefs.GetInt("SecondPlayerSkin", playerTwoPrefabs.Count - 1);
        PlayerPrefs.SetInt("SecondPlayerSkin", playerTwoIndex);
        playerOne = Instantiate(playerOnePrefabs[playerOneIndex], playerOneSpawn.transform.position, Quaternion.identity);
        if (showSecondPlayer == true) playerTwo = Instantiate(playerTwoPrefabs[playerTwoIndex], playerTwoSpawn.transform.position, Quaternion.identity);
        if (isInMenu) {
            playerOne.GetComponent<Rigidbody2D>().gravityScale = 0;
            if (showSecondPlayer == true)  playerTwo.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    private void GetSkins()
    {
        Object[] temp = Resources.LoadAll("PlayerPrefabs") as Object[];
        foreach (Object t in temp)
        {
            GameObject gm = (GameObject)t;
            if(gm.tag == "Player1")
            {
                playerOnePrefabs.Add(gm);
            }
            if(gm.tag == "Player2")
            {
                playerTwoPrefabs.Add(gm);
            }
        }
    }


    public void ChangePlayerOneSkin(int deltaIndex)
    {
        if (playerOneIndex + deltaIndex >= playerOnePrefabs.Count) deltaIndex = -playerOneIndex;
        if (playerOneIndex + deltaIndex < 0) deltaIndex = playerOnePrefabs.Count - playerOneIndex - 1;
        playerOneIndex += deltaIndex;
        PlayerPrefs.SetInt("FirstPlayerSkin", playerOneIndex);
        Destroy(playerOne);
        playerOne = Instantiate(playerOnePrefabs[playerOneIndex], playerOneSpawn.transform.position, Quaternion.identity);
        if (isInMenu) {
            playerOne.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    public void ChangePlayerTwoSkin(int deltaIndex)
    {
        if (playerTwoIndex + deltaIndex >= playerTwoPrefabs.Count) deltaIndex = -playerTwoIndex;
        if (playerTwoIndex + deltaIndex < 0) deltaIndex = playerTwoPrefabs.Count - playerTwoIndex - 1;
        playerTwoIndex += deltaIndex;
        PlayerPrefs.SetInt("SecondPlayerSkin", playerTwoIndex);
        Destroy(playerTwo);
        playerTwo = Instantiate(playerTwoPrefabs[playerTwoIndex], playerTwoSpawn.transform.position, Quaternion.identity);
        if (isInMenu) {
            playerTwo.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
}