using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour
{
    public string gameSceneName = "Gameplay"; // Name of the game scene to load
    public GameObject gameOverUI; // Reference to the game over UI GameObject

    void Start()
    {
        // Ensure game over UI is hidden at the beginning
        gameOverUI.SetActive(false);
    }

    public void ShowGameOverMenu()
    {
        // Show the game over UI
        gameOverUI.SetActive(true);
    }

    public void Retry()
    {
        // Reload the game scene
        SceneManager.LoadScene(gameSceneName);
    }
}