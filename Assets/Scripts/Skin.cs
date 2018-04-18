﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour {
    public Sprite[] skinSprites = new Sprite[14];
    public Sprite[] happyFace;
    public Sprite[] neutralFace;
    public Sprite[] sadFace;
    public enum SkinSpriteIndex
    {
        head = 0,
        torso = 1,
        leftBiceps = 2,
        rightBiceps = 3,
        leftForearm = 4,
        rightForearm = 7,
        leftThigh = 5,
        rightThigh = 6,
        leftHand = 8,
        rightHand = 11,
        leftTibia = 9,
        rightTibia = 10,
        leftFoot = 12,
        rightFoot = 13
    }
}
