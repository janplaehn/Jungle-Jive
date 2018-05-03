using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorEffect : MonoBehaviour {

    public float effectTime = 4;
    public Transform mirror;

    private const float mirrorOffset = 5.66f;
    private GameObject playerOneSpawn;
    private GameObject playerTwoSpawn;
    private GameObject mirrorInstanceOne;
    private GameObject mirrorInstanceTwo;

    private void Start() {
        playerOneSpawn = GameObject.Find("playerOneSpawn");
        playerTwoSpawn = GameObject.Find("playerTwoSpawn");
    }

    public void ActivateMirror(string tag) {
        GameObject.FindGameObjectWithTag(tag).GetComponent<MirrorMovement>().isMirrored = true;
        StartCoroutine(DeactivateMirror(tag));
        if (tag == "Player1") {
            mirrorInstanceOne = Instantiate(mirror, playerOneSpawn.transform.position + Vector3.down * mirrorOffset, Quaternion.identity).gameObject;
        }
        else if (tag == "Player2") {
            mirrorInstanceTwo = Instantiate(mirror, playerTwoSpawn.transform.position + Vector3.down * mirrorOffset, Quaternion.identity).gameObject;
        }

    }

    IEnumerator DeactivateMirror(string tag) {
        yield return new WaitForSeconds(effectTime);
        GameObject.FindGameObjectWithTag(tag).GetComponent<MirrorMovement>().isMirrored = false;
        if (tag == "Player1") {
            Destroy(mirrorInstanceOne);
        }
        else if (tag == "Player2") {
            Destroy(mirrorInstanceTwo);
        }
    }
}
