using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mushroom : MonoBehaviour {
    public static Material firstPlayerDizzy;
    public static Material secondPlayerDizzy;
    public static Material bothPlayersDizzy;
    public static Material noPlayerDizzy;
    public static Material currentMat;
    static float affectedTimer = 7.88f;
    float firstPlayerTimer = 0f;
    float secondPlayerTimer = 0f;
    static bool firstPlayerAffected = false;
    static bool secondPlayerAffected = false;

    private void Start()
    {
        if(!firstPlayerDizzy) firstPlayerDizzy = Resources.Load("Materials/LeftPlayerStunned", typeof(Material)) as Material;
        if (!secondPlayerDizzy) secondPlayerDizzy = Resources.Load("Materials/RightPlayerStunned", typeof(Material)) as Material;
        if (!bothPlayersDizzy) bothPlayersDizzy = Resources.Load("Materials/BothPlayersStunned", typeof(Material)) as Material;
        if (!noPlayerDizzy) noPlayerDizzy = Resources.Load("Materials/NoPlayerStunned", typeof(Material)) as Material;
        currentMat = noPlayerDizzy;
    }

    public void Affect(string playerTag)
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
                Invoke("ResetFirstPlayer", affectedTimer);
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
                Invoke("ResetSecondPlayer", affectedTimer);
                break;
        }
        GameObject.Find("mushroom").GetComponent<AudioSource>().Play();
    }

    private void ResetFirstPlayer()
    {
        if (currentMat == bothPlayersDizzy) currentMat = secondPlayerDizzy;
        if (currentMat == firstPlayerDizzy) currentMat = noPlayerDizzy;
    }

    private void ResetSecondPlayer()
    {
        if (currentMat == bothPlayersDizzy) currentMat = firstPlayerDizzy;
        if (currentMat == secondPlayerDizzy) currentMat = noPlayerDizzy;
    }
}
