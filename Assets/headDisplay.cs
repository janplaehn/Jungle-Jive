using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class headDisplay : MonoBehaviour {

    public bool isPlayerOne;

    private GameObject player;

	void Start () {
		
	}
	
	void Update () {
        if (!player) {
            if (isPlayerOne) {
                if (GameObject.FindGameObjectWithTag("Head"))
                    player = GameObject.FindGameObjectWithTag("Head");
            }
            else {
                if (GameObject.FindGameObjectWithTag("HeadP2"))
                    player = GameObject.FindGameObjectWithTag("HeadP2");
            }
        }
        GetComponent<Image>().sprite = player.GetComponent<SpriteRenderer>().sprite;
	}
}
