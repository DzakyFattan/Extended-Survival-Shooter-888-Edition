using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
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

}
