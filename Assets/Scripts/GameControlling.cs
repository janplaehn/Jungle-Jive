using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MusicInstructions))]
public class GameControlling : MonoBehaviour {
    public AudioClip music;
    private Pair<MusicInstructions.DanceMove, float>[] instructions = new Pair<MusicInstructions.DanceMove, float>[2];
    // Use this for initialization
    void Start()
    {
        instructions[0] = new Pair<MusicInstructions.DanceMove, float>(MusicInstructions.DanceMove.RightArmUp, 1f);
        instructions[1] = new Pair<MusicInstructions.DanceMove, float>(MusicInstructions.DanceMove.LeftArmUp, 2f);
        GetComponent<MusicInstructions>().SetMusic(music, instructions);
    }
}
