using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour {

    public GameObject comboP1;
    public GameObject comboP2;
    private int comboStreakP1;
    private int comboStreakP2;
    [SerializeField] Color noCombo;
    [SerializeField] Color smallCombo;
    [SerializeField] Color bigCombo;
	// Use this for initialization
	void Start () {
        comboStreakP1 = 0;
        comboStreakP2 = 0;
        comboP1.GetComponent<Text>().text = "Combo: " + comboStreakP1.ToString();
        comboP2.GetComponent<Text>().text = "Combo: " + comboStreakP1.ToString();

    }
	
	// Update is called once per frame
	void Update () {
        if (comboStreakP1 >= 1 && comboStreakP1 <= 2)
        {
            comboP1.GetComponent<Text>().color = smallCombo;
        }
        if (comboStreakP1 >= 3)
        {
            ScoringSystem.comboMultiplierP1 = 2;
            comboP1.GetComponent<Text>().color = bigCombo;
        }
        if (comboStreakP1 < 1)
        {
            comboP1.GetComponent<Text>().color = noCombo;
        }


        if (comboStreakP2 >= 1 && comboStreakP2 <= 2)
        {
            comboP2.GetComponent<Text>().color = smallCombo;
        }
        if (comboStreakP2 >= 3)
        {
            ScoringSystem.comboMultiplierP1 = 2;
            comboP2.GetComponent<Text>().color = bigCombo;
        }
        if (comboStreakP2 < 1)
        {
            comboP2.GetComponent<Text>().color = noCombo;
        }
    }

    public void increaseCombo (bool isPlayerOne)
    {

        if (isPlayerOne == true)
        {
            comboStreakP1++;
            comboP1.GetComponent<Text>().text = "Combo: " + comboStreakP1.ToString();
        } else
        {
            comboStreakP2++;
            comboP2.GetComponent<Text>().text = "Combo: " + comboStreakP2.ToString();
        }
    }

    public void breakCombo (bool isPlayerOne)
    {
        if (isPlayerOne == true)
        {
            comboStreakP1 = 0;
            ScoringSystem.comboMultiplierP1 = 1;
            comboP1.GetComponent<Text>().text = "Combo: " + comboStreakP1.ToString();
        }else
        {
            comboStreakP2 = 0;
            ScoringSystem.comboMultiplierP2 = 1;
            comboP2.GetComponent<Text>().text = "Combo: " + comboStreakP2.ToString();
        }

    }
}
