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
            GameObject go = (GameObject)t;
            if(go.tag == "Player1")
            {
                if(IsAlreadyInList(go, playerOnePrefabs) == false) playerOnePrefabs.Add(go);
            }
            if(go.tag == "Player2")
            {
                if (IsAlreadyInList(go, playerTwoPrefabs) == false) playerTwoPrefabs.Add(go);
            }
        }
    }

    private bool IsAlreadyInList(GameObject o, List<GameObject> list)
    {
        foreach(GameObject g in list)
        {
            if (g == o) return true;
        }
        return false;
    }

    public void ChangePlayerOneSkin(int deltaIndex)
    {
        if (playerOneIndex + deltaIndex >= playerOnePrefabs.Count)
        {
            playerOneIndex = 0;
        } else
        {
            if(playerOneIndex + deltaIndex < 0)
            {
                playerOneIndex = playerOnePrefabs.Count - 1;
            } else
            {
                playerOneIndex += deltaIndex;
            }
        }
        PlayerPrefs.SetInt("FirstPlayerSkin", playerOneIndex);
        Destroy(playerOne);
        playerOne = Instantiate(playerOnePrefabs[playerOneIndex], playerOneSpawn.transform.position, Quaternion.identity);
        if (isInMenu) {
            playerOne.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    public void ChangePlayerTwoSkin(int deltaIndex)
    {
        if (playerTwoIndex + deltaIndex >= playerTwoPrefabs.Count)
        {
            playerTwoIndex = 0;
        }
        else
        {
            if (playerTwoIndex + deltaIndex < 0)
            {
                playerTwoIndex = playerTwoPrefabs.Count - 1;
            }
            else
            {
                playerTwoIndex += deltaIndex;
            }
        }
        PlayerPrefs.SetInt("SecondPlayerSkin", playerTwoIndex);
        Destroy(playerTwo);
        playerTwo = Instantiate(playerTwoPrefabs[playerTwoIndex], playerTwoSpawn.transform.position, Quaternion.identity);
        if (isInMenu) {
            playerTwo.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
}