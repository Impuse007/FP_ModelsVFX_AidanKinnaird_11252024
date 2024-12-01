using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    // This method will be called when the button is pressed
    public void ExitGame()
    {
        // Check if we are running in the Unity Editor
#if UNITY_EDITOR
        // Stop playing the game in the editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Otherwise, quit the game (works in a build)
        Application.Quit();
#endif
        Debug.Log("Game is exiting...");
    }
}

