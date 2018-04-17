using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DanceMove {
    public float RightArmPosition;
    public float LeftArmPosition;
    public float RightLegPosition;
    public float LeftLegPosition;
    public int instructionImageIndex;
    public DanceMove(float rightArm, float leftArm, float rightLeg, float leftLeg, int index)
    {
        RightArmPosition = rightArm;
        LeftArmPosition = leftArm;
        RightLegPosition = rightLeg;
        LeftLegPosition = leftLeg;
        instructionImageIndex = index;
    }
}
