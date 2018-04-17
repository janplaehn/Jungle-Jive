using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Text))]
public class LeaderBoard : MonoBehaviour {
    int newScorePlayerOne = -1;
    int newScorePlayerTwo = -1;
    const int leaderBoardLength = 10;
    public Text[] leaderBoardText;
    public float goToMenuTimer;

	void Start () {
        GetLeaderBoard();
        Invoke("GoToMenu", goToMenuTimer);
    }

    void GetLeaderBoard()
    {
        int[] scoreArray = SetScoreArray();
        SetScoreStringArray();
        for (int i = scoreArray.Length - 1; i >= 0 ; i--)
        {
            if (scoreArray[i] < PlayerPrefs.GetInt(ScoringSystem.firstPlayerScoreKey, 0))
            {
                ReplaceValueInIntArray(i, PlayerPrefs.GetInt(ScoringSystem.firstPlayerScoreKey), scoreArray, NameInput.playerOneName);
                newScorePlayerOne = PlayerPrefs.GetInt(ScoringSystem.firstPlayerScoreKey);
                break;
            }
        }

        for (int i = scoreArray.Length - 1; i >= 0; i--)
        {
            if (scoreArray[i] < PlayerPrefs.GetInt(ScoringSystem.secondPlayerScoreKey, 0))
            {
                newScorePlayerTwo = PlayerPrefs.GetInt(ScoringSystem.secondPlayerScoreKey);
                ReplaceValueInIntArray(i, PlayerPrefs.GetInt(ScoringSystem.secondPlayerScoreKey), scoreArray, NameInput.playerTwoName);
                break;
            }
        }

        bool playerOneShown = false;
        bool playerTwoShown = false;
        for(int i = leaderBoardText.Length - 1; i >= 0; i--)
        {
            string temp = (Mathf.Abs(i - scoreArray.Length + 1) + 1).ToString() + " : " + (PlayerPrefs.GetString("HighScoreString" + i.ToString(), "")) + " : " + scoreArray[i].ToString() + " points";
            if(newScorePlayerOne == scoreArray[i] && !playerOneShown)
            {
                temp += " New Highscore Player One!";
                playerOneShown = true;
            } else
            {
                if (newScorePlayerTwo == scoreArray[i] && !playerTwoShown)
                {
                    temp += " New Highscore Player Two!";
                    playerTwoShown = true;
                }
            }
            leaderBoardText[i].text = temp;
        }

        PlayerPrefs.SetInt(ScoringSystem.firstPlayerScoreKey, 0);
        PlayerPrefs.SetInt(ScoringSystem.secondPlayerScoreKey, 0);
    }

    int[] SetScoreArray()
    {
        int[] temp = new int[leaderBoardLength];
        for (int i = temp.Length - 1; i >= 0; i--)
        {
            temp[i] = PlayerPrefs.GetInt("HighScore" + i.ToString(), (i + 1) * 100);
            PlayerPrefs.SetInt("HighScore" + i.ToString(), temp[i]);
        }
        return temp;
    }

    string[] SetScoreStringArray()
    {
        string[] temp = new string[leaderBoardLength];
        for (int i = temp.Length - 1; i >= 0; i--)
        {
            if(PlayerPrefs.GetString("HighScoreString" + i.ToString(), "") == "")
            {
                PlayerPrefs.SetString("HighScoreString" + i.ToString(), GetRandomString(3));
            }
            temp[i] = PlayerPrefs.GetString("HighScoreString" + i.ToString(), "");
        }
        return temp;
    }

    void ReplaceValueInIntArray(int index, int valueToPlace, int[] array, string name)
    {
        int a = array[index];
        string b = PlayerPrefs.GetString("HighScoreString" + index.ToString(), "");
        array[index] = valueToPlace;
        PlayerPrefs.SetInt("HighScore" + index.ToString(), array[index]);
        PlayerPrefs.SetString("HighScoreString" + index.ToString(), name);

        if (index > 0)
        {
            ReplaceValueInIntArray(index-1, a, array, b);
        }
    }

    string GetRandomString(int numberOfChars)
    {
        string temp = "";
        for(int i = 0; i < numberOfChars; i++)
        {
            char t = (char)Random.Range(65, 91);
            temp += t;
        }
        return temp;
    }

    void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
