using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LeaderBoard : MonoBehaviour {
    int newScorePlayerOne = -1;
    int newScorePlayerTwo = -1;
    bool draw = false;
    const int leaderBoardLength = 10;
    public Text[] leaderBoardText;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt(ScoringSystem.secondPlayerScoreKey, 520);
        GetLeaderBoard();
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
            string temp = "High Score " + (i + 1).ToString() + " : " + scoreArray[i].ToString() + " points!";
            if(draw == true && newScorePlayerOne == scoreArray[i])
            {
                temp += " New High Score by both player!";
            } else
            {
                if(newScorePlayerOne == i)
                {
                    temp += " New High Score by player one!";
                } else
                {
                    if (newScorePlayerTwo == i)
                    {
                        temp += " New High Score by player two!";
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
}
