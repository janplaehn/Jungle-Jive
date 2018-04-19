using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinControlling : MonoBehaviour {
    static public Skin firstPlayerSkin;
    static public Skin secondPlayerSkin;
    static public Skin[] skins;
    public GameObject[] skinObjects;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        CreateSkins();
    }

    private void CreateSkins()
    {
        skins = new Skin[skinObjects.Length];
        for (int i = 0; i < skinObjects.Length; i++)
        {
            skins[i] = skinObjects[i].GetComponent<Skin>();
        }
        int firstPlayerIndex = PlayerPrefs.GetInt("FirstPlayerSkin", -1);
        if (firstPlayerIndex == -1)
        {
            PlayerPrefs.SetInt("FirstPlayerSkin", 0);
            firstPlayerIndex = 0;
        }
        int secondPlayerIndex = PlayerPrefs.GetInt("SecondPlayerSkin", -1);
        if (secondPlayerIndex == -1)
        {
            PlayerPrefs.SetInt("SecondPlayerSkin", skins.Length - 1);
            secondPlayerIndex = skins.Length - 1;
        }
        firstPlayerSkin = skins[firstPlayerIndex];
        secondPlayerSkin = skins[secondPlayerIndex];
    }

    static public void ChangeFirstPlayerSkin(int indexDifference)
    {
        int firstPlayerIndex = PlayerPrefs.GetInt("FirstPlayerSkin", -1);
        if(firstPlayerIndex + indexDifference < 0)
        {
            PlayerPrefs.SetInt("FirstPlayerSkin", skins.Length - 1);
        } else
        {
            PlayerPrefs.SetInt("FirstPlayerSkin", firstPlayerIndex + indexDifference);
        }
        firstPlayerSkin = skins[firstPlayerIndex + indexDifference];
    }

    static public void ChangeSecondPlayerSkin(int indexDifference)
    {
        int secondPlayerIndex = PlayerPrefs.GetInt("SecondPlayerSkin", -1);
        if (secondPlayerIndex + indexDifference > skins.Length - 1) {
            PlayerPrefs.SetInt("SecondPlayerSkin", 0);
        } else {
            PlayerPrefs.SetInt("SecondPlayerSkin", secondPlayerIndex + indexDifference);
        }
        secondPlayerSkin = skins[PlayerPrefs.GetInt("SecondPlayerSkin", -1)];
    }

    static public void SetFirstPlayerSkin(int index) {
        if(index > skins.Length - 1 || index < 0)
        {
            Debug.LogError("requested index out of range");
            return;
        }
        firstPlayerSkin = skins[index];
        PlayerPrefs.SetInt("FirstPlayerSkin", index);
    }

    static public void SetSecondPlayerSkin(int index) {
        if (index > skins.Length - 1 || index < 0)
        {
            Debug.LogError("requested index out of range");
            return;
        }
        secondPlayerSkin = skins[index];
        PlayerPrefs.SetInt("SecondPlayerSkin", index);
    }
}
