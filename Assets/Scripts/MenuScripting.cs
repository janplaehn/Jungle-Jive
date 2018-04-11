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
    
    public void ToggleOptions()
    {
        if(options.activeSelf == true)
        {
            options.SetActive(false);
        } else
        {
            options.SetActive(true);
        }
    }
    public void ChangeVolume()
    {
        AudioListener.volume = slider.value;
        Debug.Log(AudioListener.volume);
    }
}
