using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {

    public enum Player { Player1, Player2 };
    public Player player;

    //public GameObject playerObject;
    public GameObject[] PlayerButtons;
    public SkinSetting skinSetting;

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
                skinSetting.ChangePlayerOneSkin(1);
                break;
            case Player.Player2:
                skinSetting.ChangePlayerTwoSkin(1);
                break;
            default:
                break;
        }
    }

    public void PreviousCharacter() {
        switch (player)
        {
            case Player.Player1:
                skinSetting.ChangePlayerOneSkin(-1);
                break;
            case Player.Player2:
                skinSetting.ChangePlayerTwoSkin(-1);
                break;
            default:
                break;
        }
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