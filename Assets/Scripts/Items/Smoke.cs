using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour{
    public static GameObject smoke;

    public static void SmokeInpact (float itemX)
    {
        smoke = Resources.Load("Materials/Smoke") as GameObject;
        GameObject.Instantiate(smoke);
        smoke.transform.position = new Vector3(itemX, -4.4f, 0);
        GameObject.Find("smoke").GetComponent<AudioSource>().Play();
    }
}
