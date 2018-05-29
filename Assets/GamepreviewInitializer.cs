using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamepreviewInitializer : MonoBehaviour {

    public string previewScene;
    public string[] axes;
    public float movementThreshold;
    public float waitTime;


    public float[] axesLastInput;

    private bool hasMoved;
    private float currentTime;

    void Start() {
        hasMoved = true;
        for (int i = 0; i < axes.Length; i++) {
            axesLastInput[i] = Input.GetAxis(axes[i]);
        }
        currentTime = waitTime;
    }

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < axes.Length; i++) {
            if (Mathf.Abs(Input.GetAxis(axes[i]) - axesLastInput[i]) > movementThreshold)
                hasMoved = true;
        }
        for (int i = 0; i < axes.Length; i++) {
            axesLastInput[i] = Input.GetAxis(axes[i]);
        }

        if (!hasMoved) {
            currentTime -= Time.deltaTime;
        }
        else {
            currentTime = waitTime;
        }

        if (currentTime < 0) {
            SceneManager.LoadScene(previewScene);
        }

        hasMoved = false;
    }
}
