using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {


    private Rigidbody2D rb;
    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.transform.parent.tag == ("Player1") || collision.gameObject.transform.parent.tag == ("Player2")) {
            rb.gravityScale = 0;
            rb.velocity = Vector3.zero;
            transform.position = collision.gameObject.transform.parent.GetComponent<Getbodyparts>().ThrowingHand.transform.position;
            transform.rotation = collision.gameObject.transform.parent.GetComponent<Getbodyparts>().ThrowingHand.transform.rotation;
            transform.parent = collision.gameObject.transform.parent.GetComponent<Getbodyparts>().ThrowingHand.transform;
        }
    }

}
