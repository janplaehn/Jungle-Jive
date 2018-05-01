using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DanceMove {
    public int RightArmPosition;
    public int LeftArmPosition;
    public int RightLegPosition;
    public int LeftLegPosition;
    public int instructionImageIndex;
    public DanceMove(int rightArm, int leftArm, int rightLeg, int leftLeg, int index)
    {
        RightArmPosition = rightArm;
        LeftArmPosition = leftArm;
        RightLegPosition = rightLeg;
        LeftLegPosition = leftLeg;
        instructionImageIndex = index;
    }
}
