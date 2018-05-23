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
    public GameObject fireP1;
    public GameObject fireP2;
    private Animator fireP1Animator;
    private Animator fireP2Animator;
    [SerializeField] Color invisible;
    [SerializeField] Color noCombo;
    [SerializeField] Color smallCombo;
    [SerializeField] Color bigCombo;

    [HideInInspector] public bool isInUse;
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
        fireP1Animator = fireP1.GetComponent<Animator>();
        fireP2Animator = fireP2.GetComponent<Animator>();
        isInUse = true;

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
            fireP1.GetComponent<Image>().enabled = true;
            fireP1Animator.SetBool("FireCombo", true);
        }
        if (comboStreakP1 < 1 || !isInUse)
        {
            comboP1.GetComponent<Text>().color = invisible;
            comboP1Image.GetComponent<Image>().color = invisible;
            fireP1.GetComponent<Image>().enabled = false;
            fireP1Animator.SetBool("FireCombo", false);
        }


        if (comboStreakP2 >= 2 && comboStreakP2 <= 3)
        {
            comboP2.GetComponent<Text>().color = smallCombo;
            comboP2Image.GetComponent<Image>().color = smallCombo;
        }
        if (comboStreakP2 >= 4)
        {
            ScoringSystem.comboMultiplierP2 = 2;
            comboP2.GetComponent<Text>().color = bigCombo;
            comboP2Image.GetComponent<Image>().color = bigCombo;
            fireP2.GetComponent<Image>().enabled = true;
            fireP2Animator.SetBool("FireCombo", true);
        }
        if (comboStreakP2 < 1 || !isInUse)
        {
            comboP2.GetComponent<Text>().color = invisible;
            comboP2Image.GetComponent<Image>().color = invisible;
            fireP2.GetComponent<Image>().enabled = false;
            fireP2Animator.SetBool("FireCombo", false);
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
