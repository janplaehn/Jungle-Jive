using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFeedback : MonoBehaviour {

    public Sprite[] spritesPerfect;
    public Sprite[] spritesGood;
    public Sprite[] spritesOk;
    public Sprite[] spritesBad;
    public Sprite[] spritesHorrible;
    public float displayDuration;

    void Start () {
        GetComponent<Image>().enabled = false;
    }
	
    public void GiveTextFeedback(int score) {
        GetComponent<Image>().enabled = true;
        switch (score) {
            case 0:
                SetSprite(spritesHorrible);
                break;
            case 25:
                SetSprite(spritesBad);
                break;
            case 50:
                SetSprite(spritesOk);
                break;
            case 75:
                SetSprite(spritesGood);
                break;
            case 100:
                SetSprite(spritesPerfect);
                break;
            default:
                Debug.LogWarning("Invalid score format " + score + " detected. Unable to display text feedback Sprite.");
                GetComponent<Image>().enabled = false;
                break;
        }
        StartCoroutine(DisableSprite());
    }

    void SetSprite(Sprite[] spriteArray) {
        int spriteNumber = Random.Range(0, spriteArray.Length - 1);
        GetComponent<Image>().overrideSprite = spriteArray[spriteNumber];
    }

    IEnumerator DisableSprite() {
        yield return new WaitForSeconds(displayDuration);
        GetComponent<Image>().enabled = false;
    }

}
