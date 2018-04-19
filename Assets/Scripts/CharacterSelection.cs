using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {

    public enum Player { Player1, Player2 };
    public Player player;

    public GameObject playerObject;
    public GameObject[] PlayerButtons;
    public GameObject Canvas;

    [HideInInspector] public static string playerCostume;
    [HideInInspector] public static string playerTwoCostume;
    [HideInInspector] public static bool wasCharacterChosen;


    private static int charactersConfirmed = 0;
    public static int skinCount = 2;

    void Start() {
    }

    public void NextCharacter() {
        switch (player) {
            case Player.Player1:
                int firstPlayerSkinIndex = PlayerPrefs.GetInt("FirstPlayerSkin", -1);
                if (PlayerPrefs.GetInt("FirstPlayerSkin", -1) < skinCount - 1) {
                    firstPlayerSkinIndex++;
                }
                else {
                    firstPlayerSkinIndex = 0;
                }
                PlayerPrefs.SetInt("FirstPlayerSkin", firstPlayerSkinIndex);
                break;
            case Player.Player2:
                int secondPlayerSkinIndex = PlayerPrefs.GetInt("SecondPlayerSkin", -1);
                if (PlayerPrefs.GetInt("SecondPlayerSkin", -1) < skinCount - 1) {
                    secondPlayerSkinIndex++;
                }
                else {
                    secondPlayerSkinIndex = 0;
                }
                PlayerPrefs.SetInt("SecondPlayerSkin", secondPlayerSkinIndex);
                break;
            default:
                break;
        }
    }

    public void PreviousCharacter() {
        switch (player) {
            case Player.Player1:
                int firstPlayerSkinIndex = PlayerPrefs.GetInt("FirstPlayerSkin", -1);
                if (PlayerPrefs.GetInt("FirstPlayerSkin", -1) > 0) {
                    firstPlayerSkinIndex--;
                }
                else {
                    firstPlayerSkinIndex = skinCount - 1;
                }
                PlayerPrefs.SetInt("FirstPlayerSkin", firstPlayerSkinIndex);
                break;
            case Player.Player2:
                int secondPlayerSkinIndex = PlayerPrefs.GetInt("SecondPlayerSkin", -1);
                if (PlayerPrefs.GetInt("SecondPlayerSkin", -1) > 0) {
                    secondPlayerSkinIndex--;
                }
                else {
                    secondPlayerSkinIndex = skinCount - 1;
                }
                PlayerPrefs.SetInt("SecondPlayerSkin", secondPlayerSkinIndex);
                break;
            default:
                break;
        }
        playerObject.GetComponent<SkinSetting>().SetSkins();
    }

    public void ConfirmCharacters(string Scene) {
        foreach (GameObject button in PlayerButtons) {
                button.gameObject.SetActive(false);
            }
            if (charactersConfirmed >= 2) {
                charactersConfirmed = 0;
                SceneManager.LoadScene(Scene);
            }
    }
}