using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventHandler : MonoBehaviour
{
    private void OnEnable()
    {
        MainMenuManager.onExitButtonClicked += QuitGame;
    }

    private void OnDisable()
    {
        MainMenuManager.onExitButtonClicked -= QuitGame;
    }

    public void QuitGame()
    {
#if UNITY_STANDALONE
        //Quit the application
        Application.Quit();
#endif

        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
