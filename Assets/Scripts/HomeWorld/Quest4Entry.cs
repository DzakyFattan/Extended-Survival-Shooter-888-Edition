using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest4Entry : MonoBehaviour
{
    // on trigger entry, redirect to 'MazeQuest' scene
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadSceneAsync("FourthQuest");
        }
    }

}
