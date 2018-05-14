using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DanceMove : UnityEngine.MonoBehaviour
{
    public enum LimbState
    {
        Down = 0,
        Middle = 1,
        Up = 2,
        None = -1
    }

    public LimbState RightArmPosition;
    public LimbState LeftArmPosition;
    public LimbState RightLegPosition;
    public LimbState LeftLegPosition;
    public Sprite moveInstruction;
    public MusicInstructions.DanceMoveEnum instructionImageIndex;
}

public struct TempMove 
{
    public enum LimbState
    {
        Down = 0,
        Middle = 1,
        Up = 2,
        None = -1
    }

    public LimbState RightArmPosition;
    public LimbState LeftArmPosition;
    public LimbState RightLegPosition;
    public LimbState LeftLegPosition;
    public MusicInstructions.DanceMoveEnum instructionImageIndex;
}