using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFeedback : MonoBehaviour {
    public GameObject feedbackObject;
    public Sprite[] spritesPerfect;
    public Sprite[] spritesGood;
    public Sprite[] spritesOk;
    public Sprite[] spritesBad;
    public Sprite[] spritesHorrible;
    public float displayDuration;
	
    public void GiveTextFeedback(int score) {
        GameObject temp = Instantiate(feedbackObject, transform.position, transform.rotation);
        switch (score) {
            case 0:
                temp.GetComponent<FeedBackSprite>().SetSprite(SetSprite(spritesHorrible));
                break;
            case 25:
                temp.GetComponent<FeedBackSprite>().SetSprite(SetSprite(spritesBad));
                break;
            case 50:
                temp.GetComponent<FeedBackSprite>().SetSprite(SetSprite(spritesOk));
                break;
            case 75:
                temp.GetComponent<FeedBackSprite>().SetSprite(SetSprite(spritesGood));
                break;
            case 100:
                temp.GetComponent<FeedBackSprite>().SetSprite(SetSprite(spritesPerfect));
                break;
            default:
                temp.GetComponent<FeedBackSprite>().SetSprite(SetSprite(spritesPerfect));
                Debug.LogWarning("Invalid score format " + score + " detected. Unable to display text feedback Sprite.");
                break;
        }
    }

    Sprite SetSprite(Sprite[] spriteArray) {
        return spriteArray[Random.Range(0, spriteArray.Length)];
    }
}
