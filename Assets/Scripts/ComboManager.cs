using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour {

    public GameObject comboP1;
    public GameObject comboP2;
    public GameObject comboP1Image;
    public GameObject comboP2Image;
    private int comboStreakP1;
    private int comboStreakP2;
    [SerializeField] Color invisible;
    [SerializeField] Color noCombo;
    [SerializeField] Color smallCombo;
    [SerializeField] Color bigCombo;
	// Use this for initialization
	void Start () {
        comboStreakP1 = 0;
        comboStreakP2 = 0;
        comboP1.GetComponent<Text>().text = comboStreakP1.ToString();
        comboP2.GetComponent<Text>().text = comboStreakP1.ToString();
        comboP1Image.GetComponent<Image>().color = invisible;
        comboP2Image.GetComponent<Image>().color = invisible;
        ScoringSystem.comboMultiplierP1 = 1;
        ScoringSystem.comboMultiplierP1 = 1;


    }
	
	// Update is called once per frame
	void Update () {
        if (comboStreakP1 >= 2 && comboStreakP1 <= 3)
        {
            comboP1.GetComponent<Text>().color = smallCombo;
            comboP1Image.GetComponent<Image>().color = smallCombo;
        }
        if (comboStreakP1 >= 4)
        {
            ScoringSystem.comboMultiplierP1 = 2;
            comboP1.GetComponent<Text>().color = bigCombo;
            comboP1Image.GetComponent<Image>().color = bigCombo;
        }
        if (comboStreakP1 < 1)
        {
            comboP1.GetComponent<Text>().color = invisible;
            comboP1Image.GetComponent<Image>().color = invisible;
        }


        if (comboStreakP2 >= 2 && comboStreakP2 <= 3)
        {
            comboP2.GetComponent<Text>().color = smallCombo;
            comboP2Image.GetComponent<Image>().color = smallCombo;
        }
        if (comboStreakP2 >= 4)
        {
            ScoringSystem.comboMultiplierP1 = 2;
            comboP2.GetComponent<Text>().color = bigCombo;
            comboP2Image.GetComponent<Image>().color = bigCombo;
        }
        if (comboStreakP2 < 1)
        {
            comboP2.GetComponent<Text>().color = invisible;
            comboP2Image.GetComponent<Image>().color = invisible;
        }
    }

    public void increaseCombo (bool isPlayerOne)
    {

        if (isPlayerOne == true)
        {
            comboStreakP1++;
            comboP1.GetComponent<Text>().text =comboStreakP1.ToString();
        } else
        {
            comboStreakP2++;
            comboP2.GetComponent<Text>().text =comboStreakP2.ToString();
        }
    }

    public void breakCombo (bool isPlayerOne)
    {
        if (isPlayerOne == true)
        {
            comboStreakP1 = 0;
            ScoringSystem.comboMultiplierP1 = 1;
            comboP1.GetComponent<Text>().text =comboStreakP1.ToString();
        }else
        {
            comboStreakP2 = 0;
            ScoringSystem.comboMultiplierP2 = 1;
            comboP2.GetComponent<Text>().text =comboStreakP2.ToString();
        }

    }
}
