using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSceneChecker : MonoBehaviour
{
    // On trigger enter 3d
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CheckQuests();
        }
    }

    void CheckQuests()
    {
        int distQuestCompleted = 0;
        List<int> completedQuests = new List<int>();
        
        for (int i = 0; i < State.Instance.completedQuests.Count; i++)
        {
            if (!completedQuests.Contains(State.Instance.completedQuests[i]))
            {
                completedQuests.Add(State.Instance.completedQuests[i]);
                distQuestCompleted++;
            }
        }

        if (distQuestCompleted >= 4)
        {
            SceneManager.LoadScene("MidScene");
        }
    }
}
