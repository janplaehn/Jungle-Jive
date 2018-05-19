using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsFeedback : MonoBehaviour
{
    private Color noFeedbackColor = new Color(0,0,0,0);
    [SerializeField]
    private Color perfectColor;
    [SerializeField]
    private Color goodColor;
    [SerializeField]
    private Color okColor;
    [SerializeField]
    private Color badColor;
    [SerializeField]
    private Color leftPlayerColor;
    [SerializeField]
    private Color rightPlayerColor;

    public float lightTimer;
    public SpriteRenderer firstPlayerLight;
    public SpriteRenderer secondPlayerLight;
    bool someoneWon = false;

    enum FeedBackType
    {
        none,
        perfect,
        good,
        ok,
        bad
    }

    private void Start()
    {
        firstPlayerLight.color = secondPlayerLight.color = noFeedbackColor;
    }

    public void GiveFirstPlayerFeedback(int score, int maxScore)
    {
        FeedBackType f = CheckScore(score, maxScore);
        switch (f)
        {
            case FeedBackType.bad:
                SetFirstPlayerLight(badColor);
                break;
            case FeedBackType.ok:
                SetFirstPlayerLight(okColor);
                break;
            case FeedBackType.good:
                SetFirstPlayerLight(goodColor);
                break;
            case FeedBackType.perfect:
                SetFirstPlayerLight(perfectColor);
                break;
            default:
                Debug.LogError("Couldn't give proper light feedback for player 1 :( ");
                break;
        }
        
    }

    public void GiveSecondPlayerFeedback(int score, int maxScore)
    {
        FeedBackType f = CheckScore(score, maxScore);
        switch (f)
        {
            case FeedBackType.bad:
                SetSecondPlayerLight(badColor);
                break;
            case FeedBackType.ok:
                SetSecondPlayerLight(okColor);
                break;
            case FeedBackType.good:
                SetSecondPlayerLight(goodColor);
                break;
            case FeedBackType.perfect:
                SetSecondPlayerLight(perfectColor);
                break;
            default:
                Debug.LogError("Couldn't give proper light feedback for player 2 :( ");
                break;
        }

    }


    private FeedBackType CheckScore(int score, int maxScore)
    {
        float percentage = ((float)(score) / (float)(maxScore)) * 100f;
        if (percentage < 25f)
        {
            return FeedBackType.bad;
        }
        else if (percentage >= 25f && percentage < 50f)
        {
            return FeedBackType.ok;
        }
        else if (percentage >= 50f && percentage < 75f)
        {
            return FeedBackType.good;
        }
        else if (percentage >= 75f)
        {
            return FeedBackType.perfect;
        }
        return FeedBackType.none;
    }

    private void SetFirstPlayerLight(Color color)
    {
        firstPlayerLight.color = color;
        Invoke("ResetFirstPlayerLight", lightTimer);
    }

    private void ResetFirstPlayerLight()
    {
        if (!someoneWon) firstPlayerLight.color = noFeedbackColor;
    }

    private void SetSecondPlayerLight(Color color)
    {
        secondPlayerLight.color = color;
        Invoke("ResetSecondPlayerLight", lightTimer);
    }

    private void ResetSecondPlayerLight()
    {
        if (!someoneWon) secondPlayerLight.color = noFeedbackColor;
    }


    public void LeftPlayerWins()
    {
        secondPlayerLight.color = firstPlayerLight.color = leftPlayerColor;
        someoneWon = true;
    }

    public void RightPlayerWins()
    {
        secondPlayerLight.color = firstPlayerLight.color = rightPlayerColor;
        someoneWon = true;
    }
}
