using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    void Start()
    {
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
        SceneManager.LoadScene("OpeningScene");
    }

    public void LoadQuestMenu()
    {
        // unload the current scene
        // SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        // load a scene called "QuestMenu"
        SceneManager.LoadScene("QuestMenu");
    }

    public void QuitGame()
    {
        // quit the game
        Application.Quit();
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
