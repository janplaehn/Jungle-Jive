using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Banana  {

    public static void BananaHit(string playerTag)
    {
        if (playerTag != "Player1" && playerTag != "Player2") {
            Debug.LogWarning("Invalid Playertag!");
            return;
        }
        GameObject disabledPlayer = GameObject.FindGameObjectWithTag(playerTag);
        LimbMovement[] limbs = disabledPlayer.GetComponentsInChildren<LimbMovement>();
        for (int i = 0; i < limbs.Length; i++)
        {
            limbs[i].SetStun(0f);
        }
        GameObject.Find("bananaSmashCollider").GetComponent<CircleCollider2D>().enabled = true;
        if (playerTag == "Player1") {
            GameObject.Find("bananaSmashCollider").GetComponent<Rigidbody2D>().AddForce(Vector3.left * 10000);
        }
        else {
            GameObject.Find("bananaSmashCollider").GetComponent<Rigidbody2D>().AddForce(Vector3.right * 10000);
        }
        disabledPlayer.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GameObject.Find("banana").GetComponent<AudioSource>().Play();
        switch (GameObject.FindGameObjectWithTag(playerTag).name)
        {
            case "Bridget_PlayerOne(Clone)":
                GameObject.Find("playerSound").GetComponent<AudioSource>().PlayOneShot(Resources.Load("Sound/BridgetScream.ogg" ) as AudioClip);
                break;
            case "Jakob_PlayerOne(Clone)":
                GameObject.Find("playerSound").GetComponent<AudioSource>().PlayOneShot(Resources.Load("Sound/JakobScream.ogg") as AudioClip);
                break;
            case "Hector_PlayerOne(Clone)":
                GameObject.Find("playerSound").GetComponent<AudioSource>().PlayOneShot(Resources.Load("Sound/HectorScream.ogg") as AudioClip);
                break;
            case "Isabell_PlayerOne(Clone)":
                GameObject.Find("playerSound").GetComponent<AudioSource>().PlayOneShot(Resources.Load("Sound/IsabellScream.ogg") as AudioClip);
                break;
            default:
                break;
        }
    }

    public static IEnumerator FlyOff(string playerTag) {
        yield return new WaitForSeconds(2.5f);
        GameObject.FindGameObjectWithTag(playerTag).GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GameObject.FindGameObjectWithTag(playerTag).GetComponent<Rigidbody2D>().gravityScale = 0;
        GameObject.FindGameObjectWithTag(playerTag).transform.localScale = new Vector3 (0.3f, 0.3f, 0.3f);
        if (playerTag == "Player1") {
            GameObject.FindGameObjectWithTag(playerTag).transform.position = new Vector3(-11, -3, -1);
            GameObject.FindGameObjectWithTag(playerTag).GetComponent<Rigidbody2D>().AddForce(new Vector3(1, 0.6f) * 200);
            GameObject.FindGameObjectWithTag(playerTag).GetComponent<Rigidbody2D>().AddTorque(-10);            
        }
        else if (playerTag == "Player2") {
            GameObject.FindGameObjectWithTag(playerTag).transform.position = new Vector3(11, -3, -1);
            GameObject.FindGameObjectWithTag(playerTag).GetComponent<Rigidbody2D>().AddForce(new Vector3(-1, 0.6f) * 200);
            GameObject.FindGameObjectWithTag(playerTag).GetComponent<Rigidbody2D>().AddTorque(10);
        }
        GameObject.FindGameObjectWithTag(playerTag).GetComponent<Rigidbody2D>().gravityScale = 0;
    }

        public static IEnumerator ResetPositions(string playerTag, GameObject smashCollider) {
        yield return new WaitForSeconds(7.88f);
        GameObject.FindGameObjectWithTag(playerTag).transform.localScale = new Vector3(1, 1, 1);
        GameObject.FindGameObjectWithTag(playerTag).transform.rotation = Quaternion.identity;
        GameObject.FindGameObjectWithTag(playerTag).GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GameObject.FindGameObjectWithTag(playerTag).GetComponent<Rigidbody2D>().gravityScale = 1;
        GameObject.FindGameObjectWithTag(playerTag).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        if (playerTag == "Player1") {
            GameObject.FindGameObjectWithTag(playerTag).transform.position = GameObject.Find("playerOneSpawn").transform.position + Vector3.up * 10;
        }
        else if (playerTag == "Player2") {
            GameObject.FindGameObjectWithTag(playerTag).transform.position = GameObject.Find("playerTwoSpawn").transform.position + Vector3.up * 10;
        }
        smashCollider.GetComponent<CircleCollider2D>().enabled = false;
        smashCollider.transform.position = new Vector3(0, 0.9f, 0);
        smashCollider.transform.rotation = Quaternion.identity;
        smashCollider.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

}
