using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Text))]
public class LeaderBoard : MonoBehaviour {
    int newScorePlayerOne = -1;
    int newScorePlayerTwo = -1;
    bool draw = false;
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
        for (int i = scoreArray.Length - 1; i >= 0 ; i--)
        {
            if (scoreArray[i] < PlayerPrefs.GetInt(ScoringSystem.firstPlayerScoreKey, 0))
            {
                ReplaceValueInIntArray(i, PlayerPrefs.GetInt(ScoringSystem.firstPlayerScoreKey), scoreArray);
                newScorePlayerOne = PlayerPrefs.GetInt(ScoringSystem.firstPlayerScoreKey);
                break;
            }
        }

        for (int i = scoreArray.Length - 1; i >= 0; i--)
        {
            if (scoreArray[i] < PlayerPrefs.GetInt(ScoringSystem.secondPlayerScoreKey, 0))
            {
                newScorePlayerTwo = PlayerPrefs.GetInt(ScoringSystem.secondPlayerScoreKey);
                if (newScorePlayerOne == newScorePlayerTwo)
                {
                    draw = true;
                } else
                {
                    ReplaceValueInIntArray(i, PlayerPrefs.GetInt(ScoringSystem.secondPlayerScoreKey), scoreArray);
                }

                break;
            }
        }

        for(int i = leaderBoardText.Length - 1; i >= 0; i--)
        {
            string temp = (Mathf.Abs(i - scoreArray.Length + 1) + 1).ToString() + " : " + scoreArray[i].ToString() + " points";
            if(draw == true && newScorePlayerOne == scoreArray[i])
            {
                temp += " New Highscores!";
            } else
            {
                if(newScorePlayerOne == scoreArray[i])
                {
                    temp += " New Highscore Player One!";
                    temp = NameInput.playerOneName + " " + temp;
                } else
                {
                    if (newScorePlayerTwo == scoreArray[i])
                    {
                        temp += " New Highscore Player Two!";
                        temp = NameInput.playerTwoName + " " + temp;
                    }
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

    void ReplaceValueInIntArray(int index, int valueToPlace, int[] array)
    {
        int a = array[index];
        array[index] = valueToPlace;
        PlayerPrefs.SetInt("HighScore" + index.ToString(), array[index]);
        if (index > 0)
        {
            ReplaceValueInIntArray(index-1, a, array);
        }
    }

    void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
