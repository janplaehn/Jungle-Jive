using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSetting : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    public Skin.SkinSpriteIndex index;
    public bool isFirstPlayer;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

    public void SetSkin()
    {
        if (spriteRenderer)
        {
            if (isFirstPlayer)
            {
                spriteRenderer.sprite = SkinControlling.firstPlayerSkin.skinSprites[(int)index];
            }
            else
            {
                spriteRenderer.sprite = SkinControlling.secondPlayerSkin.skinSprites[(int)index];
            }
        }
    }

    public void SetSkins()
    {
        SetSkin();
        SkinSetting[] skinSettings = gameObject.GetComponentsInChildren<SkinSetting>();
        foreach (SkinSetting s in skinSettings) {
            s.SetSkin();
        }
    }
}
