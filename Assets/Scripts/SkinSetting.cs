using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSetting : MonoBehaviour {
    public GameObject[] playerOnePrefabs;
    public GameObject[] playerTwoPrefabs;
    private int playerOneIndex;
    private int playerTwoIndex;
    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject playerOneSpawn;
    public GameObject playerTwoSpawn;
    public bool startMenu;
	// Use this for initialization
	void Start () {
        playerOneIndex = PlayerPrefs.GetInt("FirstPlayerSkin", 0);
        PlayerPrefs.SetInt("FirstPlayerSkin", playerOneIndex);
        playerTwoIndex = PlayerPrefs.GetInt("SecondPlayerSkin", playerTwoPrefabs.Length - 1);
        PlayerPrefs.SetInt("SecondPlayerSkin", playerTwoIndex);
        playerOne = Instantiate(playerOnePrefabs[playerOneIndex], playerOneSpawn.transform.position, Quaternion.identity);
        if (startMenu == false) playerTwo = Instantiate(playerTwoPrefabs[playerTwoIndex], playerTwoSpawn.transform.position, Quaternion.identity);
    }

    public void ChangePlayerOneSkin(int deltaIndex)
    {
        if (playerOneIndex + deltaIndex >= playerOnePrefabs.Length) deltaIndex = -playerOneIndex;
        if (playerOneIndex + deltaIndex < 0) deltaIndex = playerOnePrefabs.Length - playerOneIndex - 1;
        playerOneIndex += deltaIndex;
        PlayerPrefs.SetInt("FirstPlayerSkin", playerOneIndex);
        Destroy(playerOne);
        Instantiate(playerOnePrefabs[playerOneIndex], playerOneSpawn.transform.position, Quaternion.identity);
    }

    public void ChangePlayerTwoSkin(int deltaIndex)
    {
        if (playerTwoIndex + deltaIndex >= playerTwoPrefabs.Length) deltaIndex = -playerTwoIndex;
        if (playerTwoIndex + deltaIndex < 0) deltaIndex = playerTwoPrefabs.Length - playerTwoIndex - 1;
        playerTwoIndex += deltaIndex;
        PlayerPrefs.SetInt("SecondPlayerSkin", playerTwoIndex);
        Destroy(playerTwo);
        Instantiate(playerTwoPrefabs[playerTwoIndex], playerTwoSpawn.transform.position, Quaternion.identity);
    }
}