using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {

    public enum Player { Player1, Player2 };
    public Player player;

    public GameObject playerObject;
    public GameObject[] PlayerButtons;

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
                if (PlayerPrefs.GetInt("FirstPlayerSkin", 0) < SkinControlling.skins.Length - 1) {
                    SkinControlling.ChangeFirstPlayerSkin(1);
                }
                else {
                    SkinControlling.SetFirstPlayerSkin(0);
                }
                break;
            case Player.Player2:
                if (PlayerPrefs.GetInt("SecondPlayerSkin", 0) < SkinControlling.skins.Length - 1) {
                    SkinControlling.ChangeSecondPlayerSkin(1);
                }
                else {
                    SkinControlling.SetSecondPlayerSkin(0);
                }
                break;
            default:
                break;
        }
        playerObject.GetComponent<SkinSetting>().SetSkins();
    }

    public void PreviousCharacter() {
        switch (player) {
            case Player.Player1:
                if (PlayerPrefs.GetInt("FirstPlayerSkin", -1) > 0) {
                    SkinControlling.ChangeFirstPlayerSkin(-1);
                }
                else {
                    SkinControlling.SetFirstPlayerSkin(SkinControlling.skins.Length - 1);
                }
                break;
            case Player.Player2:
                if (PlayerPrefs.GetInt("SecondPlayerSkin", -1) > 0) {
                    SkinControlling.ChangeSecondPlayerSkin(-1);
                }
                else {
                    SkinControlling.SetSecondPlayerSkin(SkinControlling.skins.Length - 1);
                }
                break;
            default:
                break;
        }
        playerObject.GetComponent<SkinSetting>().SetSkins();
    }

    public void ConfirmCharacters(string Scene) {
        charactersConfirmed++;
        foreach (GameObject button in PlayerButtons) {
                button.gameObject.SetActive(false);
            }
            if (charactersConfirmed >= 2) {
                charactersConfirmed = 0;
                SceneManager.LoadScene(Scene);
            }
    }
}