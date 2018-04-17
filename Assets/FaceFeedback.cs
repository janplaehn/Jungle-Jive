﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceFeedback : MonoBehaviour {

    public Sprite[] happyFace;
    public Sprite[] neutralFace;
    public Sprite[] sadFace;

    public void GiveFaceFeedback(int score, int maxScore) {
        float percentage = ((float)(score) / (float)(maxScore)) * 100f;
        if (percentage == 0f)
        {
            SetSprite(sadFace);
        }
        else if (percentage < 25f && percentage != 0f)
        {
            SetSprite(sadFace);
        }
        else if (percentage >= 25f && percentage < 50f)
        {
            SetSprite(neutralFace);
        }
        else if (percentage >= 50f && percentage < 75f)
        {
            SetSprite(happyFace);
        }
        else if (percentage >= 75f)
        {
            SetSprite(happyFace);
        }
        else
        {
            SetSprite(neutralFace);
            Debug.LogWarning("Invalid score format " + percentage + " detected. Unable to display face feedback Sprite.");
        }
        
    }

    void SetSprite(Sprite[] spriteArray) {
        int spriteNumber = Random.Range(0, spriteArray.Length);
        GetComponent<SpriteRenderer>().sprite = spriteArray[spriteNumber];
    }
}