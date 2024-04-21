using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1); // Load the play scene
                                               // Function to load a scene by its name
     

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