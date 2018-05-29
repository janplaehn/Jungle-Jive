using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamepreviewController : MonoBehaviour {

    public string menuScene;
    public string[] axes;
    public float movementThreshold;


    public float[] axesLastInput;

    void Start () {
        for (int i = 0; i < axes.Length; i++) {
            axesLastInput[i] = Input.GetAxis(axes[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < axes.Length; i++) {
            if (Mathf.Abs(Input.GetAxis(axes[i]) - axesLastInput[i]) > movementThreshold)
                SceneManager.LoadScene(menuScene);
        }
        for (int i = 0; i < axes.Length; i++) {
            axesLastInput[i] = Input.GetAxis(axes[i]);
        }
    }
}
