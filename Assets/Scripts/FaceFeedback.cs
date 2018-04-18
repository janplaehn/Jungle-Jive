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
                SetSprite(GameControlling.firstPlayerSkin.sadFace);
            } else
            {
                SetSprite(GameControlling.secondPlayerSkin.sadFace);
            }
        }
        else if (percentage >= 25f && percentage < 50f)
        {
            if (isPlayerOne)
            {
                SetSprite(GameControlling.firstPlayerSkin.neutralFace);
            }
            else
            {
                SetSprite(GameControlling.secondPlayerSkin.neutralFace);
            }
        }
        else if ((percentage >= 50f && percentage < 75f) || percentage >= 75f)
        {
            if (isPlayerOne)
            {
                SetSprite(GameControlling.firstPlayerSkin.happyFace);
            }
            else
            {
                SetSprite(GameControlling.secondPlayerSkin.happyFace);
            }
        }
        else
        {
            SetSprite(GameControlling.firstPlayerSkin.neutralFace);
            Debug.LogWarning("Invalid score format " + percentage + " detected. Unable to display face feedback Sprite.");
        }
        
    }

    void SetSprite(Sprite[] spriteArray) {
        int spriteNumber = Random.Range(0, spriteArray.Length);
        GetComponent<SpriteRenderer>().sprite = spriteArray[spriteNumber];
    }
}