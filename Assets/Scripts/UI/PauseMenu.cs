using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject mapMenuUI;

    public GameObject optionsMenuUI;
    
    
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
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
        if (Input.GetKeyUp(KeyCode.Q) && mapMenuUI.activeInHierarchy == true)
        {
            mapMenuUI.SetActive(false);
            Resume();
        }
        if (Input.GetKeyUp(KeyCode.Q) && optionsMenuUI.activeInHierarchy == true)
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

    public void OnMapButton()
    {
        mapMenuUI.SetActive(true);
    }

    public void OnOptionsMenu()
    {
        optionsMenuUI.SetActive(true);
    }

    public void OnQuitButton()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}