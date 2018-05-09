using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsFeedback : MonoBehaviour
{


    public Light lightFeedback;
    public bool trigger = true;
    public float brightness = 2;
    public float reactionTime = 2; //the time of dance instuctions being displayed
    private bool deactivating = false;
    private float amplitude;
    private float phi;
    private float accumulatedTime;


    void Update()
    {
        //connect it to the GameController

        if (trigger == true)
        {
            accumulatedTime += Time.deltaTime;

            if (deactivating == true)
            {
                deactivating = false;
                accumulatedTime = 1.9f * Mathf.PI;
            }
            else
            {
                phi = accumulatedTime / reactionTime * 2 * Mathf.PI;
            }

            amplitude = (Mathf.Cos(phi) * 0.5f + 0.5f) * brightness;
            lightFeedback.intensity = amplitude;

        }
        else
        {
            lightFeedback.intensity = Mathf.Lerp(lightFeedback.intensity, 0, Time.deltaTime / reactionTime * Mathf.PI);
            deactivating = true;
        }



    }
}
