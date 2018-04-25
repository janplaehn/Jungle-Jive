using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceFeedbackController : MonoBehaviour {
    public Sprite[] sad;
    public Sprite[] neutral;
    public Sprite[] happy;


    public void GiveFaceFeedback(int score, int maxScore) {
        float percentage = ((float)(score) / (float)(maxScore)) * 100f;
        if (percentage == 0f || (percentage < 25f && percentage != 0f)) {
            SetSprite(sad);
        }
        else if (percentage >= 25f && percentage < 50f) {
            SetSprite(neutral);
        }
        else if ((percentage >= 50f && percentage < 75f) || percentage >= 75f) {
            SetSprite(happy);
        }
        else {
            SetSprite(neutral);
            Debug.LogWarning("Invalid score format " + percentage + " detected. Unable to display face feedback Sprite.");
        }

    }

    void SetSprite(Sprite[] spriteArray) {
        int spriteNumber = Random.Range(0, spriteArray.Length);
        GetComponent<SpriteRenderer>().sprite = spriteArray[spriteNumber];
    }
}