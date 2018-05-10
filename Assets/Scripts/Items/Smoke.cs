using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour{
    public static GameObject smoke;

    public static void SmokeInpact (string playerTag)
    {
        smoke = Resources.Load("Materials/Smoke") as GameObject;
        GameObject.Instantiate(smoke);
        if (playerTag == "Player1") smoke.transform.position = new Vector3(4, -4.4f, 0);
        else smoke.transform.position = new Vector3(-4, -4.4f, 0);
        Debug.Log(playerTag);
        GameObject.Find("smoke").GetComponent<AudioSource>().Play();
    }
}
