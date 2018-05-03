using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Getbodyparts : MonoBehaviour {

    public GameObject ThrowingHand;
    [HideInInspector] public bool hasItem = false;
    [HideInInspector] public GameObject Item;

    private void Update() {
        if (hasItem) {
            if ((gameObject.tag == "Player1" && Input.GetButton("P1ButtonA")) ||
                (gameObject.tag == "Player2" && Input.GetButton("P2ButtonA"))) {
                Item.GetComponent<Item>().AddThrowForce();
            }
        }
    }   
}
