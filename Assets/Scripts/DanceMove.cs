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
    public MusicInstructions.DanceMoveEnum instructionImageIndex;
}