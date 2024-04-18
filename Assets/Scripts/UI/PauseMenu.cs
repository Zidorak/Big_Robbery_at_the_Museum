using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject optionsMenuUI;

    public GameObject instructionsPanel;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        instructionsPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    public void Update()
    {
        if (instructionsPanel.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (Input.GetKeyUp(KeyCode.Escape) && optionsMenuUI.activeInHierarchy == true)
        {
            optionsMenuUI.SetActive(false);
            Resume();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void OnOptionsMenu()
    {
        optionsMenuUI.SetActive(true);
    }

    public void ReadyButton()
    {
        instructionsPanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
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
