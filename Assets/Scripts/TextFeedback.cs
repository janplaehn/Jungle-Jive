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
    public Sprite[] earlySprite;
    public float displayDuration;
	
    public void GiveTextFeedback(int score, int maxScore, bool isEarly) {
        GameObject temp = Instantiate(feedbackObject, transform.position, transform.rotation);
        float percentage = ((float) (score) / (float) (maxScore)) * 100f;
        if (percentage == 0f)
        {
            temp.GetComponent<FeedBackSprite>().SetSprite(SetSprite(spritesHorrible));
        }
        else if (percentage < 25f && percentage != 0f)
        {
            temp.GetComponent<FeedBackSprite>().SetSprite(SetSprite(spritesBad));
        }
        else if (percentage >= 25f && percentage < 50f)
        {
            temp.GetComponent<FeedBackSprite>().SetSprite(SetSprite(spritesOk));
        }
        else if (percentage >= 50f && percentage < 75f)
        {
            temp.GetComponent<FeedBackSprite>().SetSprite(SetSprite(spritesGood));
        }
        else if (percentage >= 75f)
        {
            temp.GetComponent<FeedBackSprite>().SetSprite(SetSprite(spritesPerfect));
        }
        else
        {
            temp.GetComponent<FeedBackSprite>().SetSprite(SetSprite(spritesPerfect));
            Debug.LogWarning("Invalid score format " + percentage + " detected. Unable to display text feedback Sprite.");
        }
        if (isEarly == true)
        {
            temp.GetComponent<FeedBackSprite>().SetSprite(SetSprite(earlySprite));
            temp.transform.localScale *= 1.5f;
        }
        /*switch (score/maxScore * 10) {
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
        }*/
    }

    Sprite SetSprite(Sprite[] spriteArray) {
        return spriteArray[Random.Range(0, spriteArray.Length)];
    }
}
