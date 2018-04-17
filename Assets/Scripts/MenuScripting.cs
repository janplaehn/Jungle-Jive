using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScripting : MonoBehaviour {
    public GameObject options;
    public Slider slider;
	public void QuitGame()
    {
        Debug.Log("Quit Requested");
        Application.Quit();
    }

    public void ChangeScene(string scene)
    {
        Debug.Log("Change Scene Requested");
        SceneManager.LoadScene(scene);
    }
    
    public void RaiseVolume() {
        if (AudioListener.volume < 1) {
            AudioListener.volume += 0.1f;
            Debug.Log(AudioListener.volume);
        }
        else {
            Debug.Log("Max volume reached");
        }
    }

    public void ReduceVolume() {
        if (AudioListener.volume > 0) {
            AudioListener.volume -= 0.1f;
            Debug.Log(AudioListener.volume);
        }
        else {
            Debug.Log("Min volume reached");
        }
    }
}
