using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mushroom : MonoBehaviour {
    public static Material firstPlayerDizzy;
    public static Material secondPlayerDizzy;
    public static Material bothPlayersDizzy;
    public static Material noPlayerDizzy;
    public static Material currentMat = noPlayerDizzy;
    static float affectedTimer = 10f;
    float firstPlayerTimer = 0f;
    float secondPlayerTimer = 0f;
    static bool firstPlayerAffected = false;
    static bool secondPlayerAffected = false;

    public static void Affect(string playerTag)
    {
        switch (playerTag)
        {
            case "Player1":
                if(currentMat == secondPlayerDizzy)
                {
                    currentMat = bothPlayersDizzy;
                } else
                {
                    currentMat = firstPlayerDizzy;
                }
                firstPlayerAffected = true;
                break;
            case "Player2":
                if (currentMat == firstPlayerDizzy)
                {
                    currentMat = bothPlayersDizzy;
                }
                else
                {
                    currentMat = secondPlayerDizzy;
                }
                secondPlayerAffected = true;
                break;
        }
    }

    private void Update()
    {
        if (firstPlayerAffected)
        {
            firstPlayerTimer += Time.deltaTime;
            if(firstPlayerTimer >= affectedTimer)
            {
                if (currentMat == bothPlayersDizzy) currentMat = secondPlayerDizzy;
                if (currentMat == firstPlayerDizzy) currentMat = noPlayerDizzy;
                firstPlayerTimer = 0f;
            }
        }
        if (secondPlayerAffected)
        {
            secondPlayerTimer += Time.deltaTime;
            if (secondPlayerTimer >= affectedTimer)
            {
                if (currentMat == bothPlayersDizzy) currentMat = firstPlayerDizzy;
                if (currentMat == secondPlayerDizzy) currentMat = noPlayerDizzy;
                secondPlayerTimer = 0f;
            }
        }
    }
}
