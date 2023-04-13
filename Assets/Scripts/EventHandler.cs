using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventHandler : MonoBehaviour
{
    private static GameObject Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log("Destroying duplicate EventHandler");
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Setting EventHandler");
            Instance = this.gameObject;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void OnEnable()
    {
        MainMenuManager.onScoreButtonClicked += LoadScoreboard;
        MainMenuManager.onExitButtonClicked += QuitGame;
        ScoreboardManager.onBackButtonClicked += BackToMainMenu;
    }

    private void OnDisable()
    {
        MainMenuManager.onScoreButtonClicked -= LoadScoreboard;
        MainMenuManager.onExitButtonClicked -= QuitGame;
        ScoreboardManager.onBackButtonClicked -= BackToMainMenu;
    }

    public void LoadScoreboard()
    {
        Debug.Log("Load Scoreboard");
        SceneManager.LoadScene("Scoreboard");
    }

    public void BackToMainMenu()
    {
        Debug.Log("Back to Main Menu");
        SceneManager.LoadScene("MainMenuAlt");
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
