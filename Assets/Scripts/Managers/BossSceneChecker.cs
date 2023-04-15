using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSceneChecker : MonoBehaviour
{
    void Start()
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

        if (distQuestCompleted >= 0)
        {
            SceneManager.LoadScene("MidScene");
        }
    }
}
