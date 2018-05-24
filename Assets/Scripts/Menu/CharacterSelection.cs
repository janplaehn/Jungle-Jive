using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {

    public enum Player { Player1, Player2 };
    public Player player;

    public AudioSource audioSource;
    public AudioClip[] bridgetClips;
    public AudioClip[] jakobClips;
    public AudioClip[] hectorClips;
    public AudioClip[] isabellClips;

    public GameObject[] PlayerButtons;
    public SkinSetting skinSetting;

    [HideInInspector] public static string playerCostume;
    [HideInInspector] public static string playerTwoCostume;
    [HideInInspector] public static bool wasCharacterChosen;


    private static int charactersConfirmed = 0;

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

    public void ConfirmCharacters() {
        charactersConfirmed++;
        if (player == Player.Player1) {
            foreach (GameObject face in GameObject.FindGameObjectsWithTag("Head")) {
                if (face.GetComponent<FaceFeedback>())
                    face.GetComponent<FaceFeedback>().BeHappy();
            }
        }
        if (player == Player.Player2) {
            foreach (GameObject face in GameObject.FindGameObjectsWithTag("HeadP2")) {
                if (face.GetComponent<FaceFeedback>())
                    face.GetComponent<FaceFeedback>().BeHappy();
            }
        }
        foreach (GameObject button in PlayerButtons) {
            button.gameObject.SetActive(false);
        }
        if (player == Player.Player1)
        {
            switch (GameObject.FindGameObjectWithTag("Player1").name) 
            {
                case "Bridget_PlayerOne(Clone)":
                    audioSource.PlayOneShot(bridgetClips[Random.Range(0, bridgetClips.Length + 1)]);
                    break;
                case "Jakob_PlayerOne(Clone)":
                    audioSource.PlayOneShot(jakobClips[Random.Range(0, jakobClips.Length + 1)]);
                    break;
                case "Hector_PlayerOne(Clone)":
                    audioSource.PlayOneShot(hectorClips[Random.Range(0, hectorClips.Length + 1)]);
                    break;
                case "Isabell_PlayerOne(Clone)":
                    audioSource.PlayOneShot(isabellClips[Random.Range(0, isabellClips.Length + 1)]);
                    break;
                default:
                    break;
            }
        } else if (player == Player.Player2)
        {
            switch (GameObject.FindGameObjectWithTag("Player2").name)
            {
                case "Bridget_PlayerOne(Clone)":
                    audioSource.PlayOneShot(bridgetClips[Random.Range(0, bridgetClips.Length + 1)]);
                    break;
                case "Jakob_PlayerOne(Clone)":
                    audioSource.PlayOneShot(jakobClips[Random.Range(0, jakobClips.Length + 1)]);
                    break;
                case "Hector_PlayerOne(Clone)":
                    audioSource.PlayOneShot(hectorClips[Random.Range(0, hectorClips.Length + 1)]);
                    break;
                case "Isabell_PlayerOne(Clone)":
                    audioSource.PlayOneShot(isabellClips[Random.Range(0, isabellClips.Length + 1)]);
                    break;
                default:
                    break;
            }
        }
        


        if (charactersConfirmed >= 2) {
            Invoke("ChangeToNextScene", 1f);
        }

    }

    public void ChangeToNextScene() {
        charactersConfirmed = 0;
        if (GameObject.Find("MusicManager")) GameObject.Find("MusicManager").GetComponent<MusicManagement>().Stop("MenuMusic");
        SceneManager.LoadScene("MainSceneShort");
    }
}