using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour{
    public static GameObject smoke;


    public static void SmokeInpact (string playerTag)
    {
        smoke = Resources.Load("Materials/Smoke") as GameObject;
        GameObject.Instantiate(smoke);
        smoke.transform.position = new Vector3(GameObject.FindGameObjectWithTag(playerTag).transform.position.x, -4.4f, 0);
    }
}
