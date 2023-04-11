using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    [SerializeField] GameObject scoreboardUI;
    private void OnEnable()
    {
        MainMenuManager.onScoreButtonClicked += LoadScoreboard;
        MainMenuManager.onExitButtonClicked += QuitGame;
    }

    private void OnDisable()
    {
        MainMenuManager.onScoreButtonClicked -= LoadScoreboard;
        MainMenuManager.onExitButtonClicked -= QuitGame;
    }

    public void LoadScoreboard()
    {
        Debug.Log("Load Scoreboard");
        scoreboardUI.SetActive(true);
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
