using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyCameraEffect : MonoBehaviour {

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, Mushroom.currentMat);
    }
}
