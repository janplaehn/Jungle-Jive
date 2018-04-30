using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour {

    [Range(0f, 8f)] public float maxXPosition;
    [Range(0f, 8f)] public float maxYPosition;
    public float speed;
    public float screenBorder;
    private GameObject playerOneSpawn;
    private GameObject playerTwoSpawn;

    private int flightdirection;
    private float radiusModifier;

    [HideInInspector] public enum FlightState {undecided, decided, dropItem, leave};
    [HideInInspector] public FlightState state = FlightState.undecided;
    [HideInInspector] public bool hasPlayerOneWon;

    void Start () {
        radiusModifier = 0.1f;
        flightdirection = 1;
        playerOneSpawn = GameObject.Find("playerOneSpawn");
        playerTwoSpawn = GameObject.Find("playerTwoSpawn");
        state = FlightState.undecided;
    }
	
	void Update () {
        switch (state) {
            case FlightState.undecided:
                FlyBackAndForth();
                break;
            case FlightState.decided:
                FlyToPlayer();
                break;
            case FlightState.dropItem:
                Invoke("DropItem", 0.5f);
                break;
            case FlightState.leave:
                LeaveScreen();
                break;
            default:
                break;              
        }
        if (System.Math.Abs(transform.position.x) > screenBorder) {
            Destroy(this.gameObject);
        }
    }

    void FlyBackAndForth() {
        transform.position += Vector3.right * Time.deltaTime * flightdirection * speed * radiusModifier;
        if (System.Math.Abs(transform.position.x) > maxXPosition * radiusModifier) {
            radiusModifier += 0.1f;
            flightdirection *= -1;
        }
        if (transform.position.y > maxYPosition) {
            transform.position += Vector3.down * Time.deltaTime * speed / 20;
        }
    }

    void FlyToPlayer() {
        if (hasPlayerOneWon) {
            flightdirection = -1;
            if (transform.position.x < playerOneSpawn.transform.position.x) {
                state = FlightState.dropItem;
            }
        }
        else {
            flightdirection = 1;
            if (transform.position.x > playerTwoSpawn.transform.position.x) {
                state = FlightState.dropItem;
            }
        }
        transform.position += Vector3.right * Time.deltaTime * flightdirection * speed * radiusModifier;

       
    }

    void DropItem() {
        foreach (Rigidbody2D rb in GetComponentsInChildren<Rigidbody2D>()) {
            rb.gravityScale = 1;
        }

        Invoke("ChangeToLeave", 0.5f);
    }

    void ChangeToLeave() {
        state = FlightState.leave;
    }
    void LeaveScreen() {
        transform.position += Vector3.right * Time.deltaTime * flightdirection * speed * radiusModifier;
    }
}
