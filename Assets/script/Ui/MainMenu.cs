using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string playSceneName = "1"; // Name of the scene to load when "Play" is clicked
    public GameObject settingsPanel; // Reference to the settings panel GameObject in the scene

    public void Play()
    {
        SceneManager.LoadScene(playSceneName); // Load the play scene
                                               // Function to load a scene by its name
     

    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true); // Activate the settings panel
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false); // Deactivate the settings panel
    }
       // Function to load a scene by its name
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop playing in the Unity Editor
#else
            Application.Quit(); // Quit the application in a build
#endif
    }
}