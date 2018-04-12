﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceFeedback : MonoBehaviour {

    public Sprite[] happyFace;
    public Sprite[] neutralFace;
    public Sprite[] sadFace;

    public void GiveFaceFeedback(int score) {
        switch (score) {
            case 0:
                SetSprite(sadFace);
                break;
            case 25:
                SetSprite(sadFace);
                break;
            case 50:
                SetSprite(neutralFace);
                break;
            case 75:
                SetSprite(happyFace);
                break;
            case 100:
                SetSprite(happyFace);
                break;
            default:
                Debug.LogWarning("Invalid score format " + score + " detected. Unable to display face feedback Sprite.");
                SetSprite(neutralFace);
                break;
        }
    }

    void SetSprite(Sprite[] spriteArray) {
        int spriteNumber = Random.Range(0, spriteArray.Length);
        GetComponent<SpriteRenderer>().sprite = spriteArray[spriteNumber];
    }
}