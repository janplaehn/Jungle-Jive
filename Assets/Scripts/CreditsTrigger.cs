using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsTrigger : MonoBehaviour {

    public GameObject Text;

    private void OnTriggerEnter2D(Collider2D collision) {
        Text.GetComponent<CreditsText>().ChangeTextState();
    }

    /*private void OnTriggerExit2D(Collider2D collision) {
        Text.GetComponent<CreditsText>().ChangeTextState();
    }*/
}
