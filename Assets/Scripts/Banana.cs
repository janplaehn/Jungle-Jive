using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Banana  {

    public static void BananaHit(string playerTag)
    {
        if (playerTag != "Player1" || playerTag != "Player2") {
            Debug.LogWarning("Invalid Playertag!");
            return;
        }
        GameObject disabledPlayer = GameObject.FindGameObjectWithTag(playerTag);
        LimbMovement[] limbs = disabledPlayer.GetComponentsInChildren<LimbMovement>();
        for (int i = 0; i < limbs.Length; i++)
        {
            limbs[i].SetStun(2);
        }
    }
}
