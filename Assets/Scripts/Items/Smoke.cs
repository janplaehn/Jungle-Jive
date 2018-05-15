using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour{
    public static GameObject smoke;

    public static void SmokeInpact (float itemX)
    {
        if(!smoke) smoke = Resources.Load("Materials/Smoke") as GameObject;
        GameObject tempSmoke = Instantiate(smoke);
        tempSmoke.transform.position = new Vector3(itemX, -4.4f, 0);
        //tempSmoke.GetComponent<AudioSource>().Play();
    }
}
