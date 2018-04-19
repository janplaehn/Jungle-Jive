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
        firstPlayerSkin = skins[firstPlayerIndex + indexDifference];
        PlayerPrefs.SetInt("FirstPlayerSkin", firstPlayerIndex + indexDifference);
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
        firstPlayerSkin = skins[index];
        PlayerPrefs.SetInt("FirstPlayerSkin", index);
    }

    static public void SetSecondPlayerSkin(int index) {
        secondPlayerSkin = skins[index];
        PlayerPrefs.SetInt("SecondPlayerSkin", index);
    }

}
