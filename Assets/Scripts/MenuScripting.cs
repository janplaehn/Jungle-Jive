using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScripting : MonoBehaviour {
    //we can just remove this tbh, alt f4 ftw
	public void QuitGame()
    {
        Debug.Log("Quit Requested");
        //Application.Quit();
    }

    public void ChangeScene(string scene)
    {
        Debug.Log("Change Scene to " + scene + " Requested");
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
