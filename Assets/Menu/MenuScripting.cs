using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripting : MonoBehaviour {

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
}
