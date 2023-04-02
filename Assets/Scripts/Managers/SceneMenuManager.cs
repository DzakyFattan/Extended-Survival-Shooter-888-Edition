using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMenuManager : MonoBehaviour
{ 
    // take one parameter, a string called "sceneName"
     public void LoadScene(string sceneName){
        SceneManager.LoadSceneAsync(sceneName);
    }
}
