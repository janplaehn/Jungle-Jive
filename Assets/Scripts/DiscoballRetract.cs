using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoballRetract : MonoBehaviour {

    public float maxYShift = 300;
    public float speed = 80;

    private Vector3 startPosition;
    private enum PullBackState {Default, Retract, Extend}
    PullBackState state = PullBackState.Default;

	void Start () {
        startPosition = transform.position;
	}

    private void Update() {
        switch (state) {
            case PullBackState.Default:
                break;
            case PullBackState.Retract:
                transform.position += Vector3.up * speed * Time.deltaTime;
                if (transform.position.y > startPosition.y + maxYShift) state = PullBackState.Default;
                break;
            case PullBackState.Extend:
                transform.position += Vector3.down * speed * Time.deltaTime;
                if (transform.position.y < startPosition.y) state = PullBackState.Default;
                break;
            default:
                break;
        }
    }

    public void Retract () {
        state = PullBackState.Retract;
	}

    public void Extend() {
        state = PullBackState.Extend;
    }
}
