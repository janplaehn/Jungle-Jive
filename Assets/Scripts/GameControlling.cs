using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MusicInstructions))]
public class GameControlling : MonoBehaviour {
    public AudioClip music;
    private Pair<DanceMove, float>[] instructions = new Pair<DanceMove, float>[2];
    // Use this for initialization
    void Start()
    {
        DanceMove temp;
        temp.instructionImageIndex = (int)MusicInstructions.DanceMoveEnum.LeftArmUp;
        temp.LeftArmPosition = 1f;
        temp.LeftLegPosition = -1f;
        temp.RightArmPosition = -1f;
        temp.RightLegPosition = -1f;
        instructions[0] = new Pair<DanceMove, float>(temp, 1f);
        DanceMove temp2;
        temp2.instructionImageIndex = (int)MusicInstructions.DanceMoveEnum.RightArmUp;
        temp2.LeftArmPosition = -1f;
        temp2.LeftLegPosition = -1f;
        temp2.RightArmPosition = 1f;
        temp2.RightLegPosition = -1f;
        instructions[1] = new Pair<DanceMove, float>(temp2, 2f);
        GetComponent<MusicInstructions>().SetMusic(music, instructions);
    }
}
