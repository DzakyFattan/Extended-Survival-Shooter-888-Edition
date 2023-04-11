using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public Button newGameButton;
    public Button questsButton;
    public Button scoreboardButton;
    public Button quitButton;

    public Button scoreboardBackButton;

    public delegate void ButtonClicked();

    public static event ButtonClicked onScoreButtonClicked;
    public static event ButtonClicked onExitButtonClicked;
    public static event ButtonClicked onScoreboardBackButtonClicked;
    void Start()
    {
        newGameButton.onClick.AddListener(LoadFirstQuest);
        questsButton.onClick.AddListener(LoadQuestMenu);
        scoreboardButton.onClick.AddListener(LoadScoreboard);
        quitButton.onClick.AddListener(QuitGame);
        scoreboardBackButton.onClick.AddListener(BackToMainMenu);
    }
    public void LoadFirstQuest()
    {
        // unload the current scene
        // SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync("OpeningScene");
    }

    public void LoadQuestMenu()
    {
        // unload the current scene
        // SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        // load a scene called "QuestMenu"
        SceneManager.LoadSceneAsync("QuestMenu");
    }

    public void LoadScoreboard()
    {
        if (onScoreButtonClicked != null)
        {
            onScoreButtonClicked?.Invoke();
        }
    }

    public void BackToMainMenu()
    {
        if (onScoreboardBackButtonClicked != null)
        {
            onScoreboardBackButtonClicked?.Invoke();
        }
    }
    public void QuitGame()
    {
        if (onExitButtonClicked != null)
        {
            onExitButtonClicked?.Invoke();
        }
    }
}
