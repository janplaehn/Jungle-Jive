﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceFeedback : MonoBehaviour {
    public bool isPlayerOne;

    public void GiveFaceFeedback(int score, int maxScore) {
        float percentage = ((float)(score) / (float)(maxScore)) * 100f;
        if (percentage == 0f || (percentage < 25f && percentage != 0f))
        {
            if (isPlayerOne)
            {
                SetSprite(SkinControlling.firstPlayerSkin.sadFace);
            } else
            {
                SetSprite(SkinControlling.secondPlayerSkin.sadFace);
            }
        }
        else if (percentage >= 25f && percentage < 50f)
        {
            if (isPlayerOne)
            {
                SetSprite(SkinControlling.firstPlayerSkin.neutralFace);
            }
            else
            {
                SetSprite(SkinControlling.secondPlayerSkin.neutralFace);
            }
        }
        else if ((percentage >= 50f && percentage < 75f) || percentage >= 75f)
        {
            if (isPlayerOne)
            {
                SetSprite(SkinControlling.firstPlayerSkin.happyFace);
            }
            else
            {
                SetSprite(SkinControlling.secondPlayerSkin.happyFace);
            }
        }
        else
        {
            SetSprite(SkinControlling.firstPlayerSkin.neutralFace);
            Debug.LogWarning("Invalid score format " + percentage + " detected. Unable to display face feedback Sprite.");
        }
        
    }

    void SetSprite(Sprite[] spriteArray) {
        int spriteNumber = Random.Range(0, spriteArray.Length);
        GetComponent<SpriteRenderer>().sprite = spriteArray[spriteNumber];
    }
}