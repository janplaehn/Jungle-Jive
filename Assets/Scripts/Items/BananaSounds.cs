using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BananaSounds : MonoBehaviour {
    public AudioClip bridgetScream;
    public AudioClip jakobScream;
    public AudioClip hectorScream;
    public AudioClip isabelleScream;
    public AudioClip monicaScream;
	
	public void PlayClip(string tag)
    {
        Debug.Log(tag);
        switch (tag)
        {
            case "Bridget":
                GameObject.Find("playerSound").GetComponent<AudioSource>().PlayOneShot(bridgetScream);
                break;
            case "Jakob":
                GameObject.Find("playerSound").GetComponent<AudioSource>().PlayOneShot(jakobScream);
                break;
            case "Hector":
                GameObject.Find("playerSound").GetComponent<AudioSource>().PlayOneShot(hectorScream);
                break;
            case "Isabelle":
                GameObject.Find("playerSound").GetComponent<AudioSource>().PlayOneShot(isabelleScream);
                break;
            case "Monica":
                GameObject.Find("playerSound").GetComponent<AudioSource>().PlayOneShot(monicaScream);
                break;
            default:
                break;
        }
    }
}
