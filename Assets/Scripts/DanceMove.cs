
[System.Serializable]
public struct DanceMove {
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
    public int instructionImageIndex;
}
