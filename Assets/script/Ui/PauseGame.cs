using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public bool isCursorVisible = false;

    private void Start()
    {
        SetCursorVisibility(isCursorVisible);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        if (pauseMenuUI.activeSelf)
            Resume();
        else
            Pause();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isCursorVisible = false;
        SetCursorVisibility(isCursorVisible);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isCursorVisible = true;
        SetCursorVisibility(isCursorVisible);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with the name of your main menu scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void SetCursorVisibility(bool visible)
    {
        Cursor.visible = visible;
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void OnResumeButtonClick()
    {
        Resume();
    }

    public void OnMainMenuButtonClick()
    {
        LoadMainMenu();
    }

    public void OnQuitButtonClick()
    {
        QuitGame();
    }
}