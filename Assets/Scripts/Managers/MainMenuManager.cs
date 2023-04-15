using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button newGameButton;
    public Button saveSlot1Button;
    public Button quitButton;
    [SerializeField] Slider volumeSlider;

    public delegate void ButtonClicked();
    public static event ButtonClicked onExitButtonClicked;
    void Start()
    {
        newGameButton.onClick.AddListener(LoadFirstQuest);
        saveSlot1Button.onClick.AddListener(LoadSavedGame);
        quitButton.onClick.AddListener(QuitGame);
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            LoadVolumeSetting();
        }
        else
        {
            LoadVolumeSetting();
        }
    }

    public void LoadFirstQuest()
    {
        // unload the current scene
        // SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Loading first quest");
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadScene("OpeningScene");
    }

    public void LoadSavedGame()
    {
        // unload the current scene
        // SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Loading saved game");
        DataPersistenceManager.instance.LoadGame();
        SceneManager.LoadScene("HomeWorld");
    }

    // public void LoadQuestMenu()
    // {
    //     // unload the current scene
    //     // SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    //     // load a scene called "QuestMenu"
    //     SceneManager.LoadScene("QuestMenu");
    // }

    public void QuitGame()
    {
        if (onExitButtonClicked != null)
        {
            onExitButtonClicked?.Invoke();
        }
    }

    public void SetVolume()
    {
        AudioListener.volume = volumeSlider.value;
        SaveVolumeSetting();
    }

    private void LoadVolumeSetting()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void SaveVolumeSetting()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
