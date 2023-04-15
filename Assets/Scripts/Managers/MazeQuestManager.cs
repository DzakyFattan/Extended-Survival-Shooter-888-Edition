using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeQuestManager : MonoBehaviour
{

    // public FloatSO scoreSO;
    public FloatSO timeSO;
    public FloatSO scoreSO;
    
    float startTime;
    float endTime;

    
    void Awake(){
        startTime = Time.time;
    }

  

    public void EndGame(){
        print("this is maze quest manager from maze quest scene");
        endTime = Time.time;
        timeSO.Value = endTime - startTime;
         State.Instance.completedQuests.Add(2);
        SceneManager.LoadScene("EndQuestScene");
    }
    public void IncrementScore(){
        scoreSO.Value += 100;
    }
}
