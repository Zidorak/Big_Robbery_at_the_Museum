using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void OnPlayButton()
    {   
        PauseMenu.gameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void OnQuitButton()
    {
#if UNITY_EDITOR
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
#endif
        Application.Quit();
    }
}
