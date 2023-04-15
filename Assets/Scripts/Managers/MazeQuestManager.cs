using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeQuestManager : MonoBehaviour
{

    // public FloatSO scoreSO;
    public FloatSO timeSO;
    
    float startTime;
    float endTime;
    
    void Awake(){
        startTime = Time.time;
    }

  

    public void EndGame(){
        endTime = Time.time;
        timeSO.Value += endTime - startTime;
        // scoreSO.Value = scoreSO.Value + timeSO.Value;
        // print("Score: " + scoreSO.Value);
        print("Time: " + timeSO.Value);
        State.Instance.completedQuests.Add(2);
        // State.Instance.score += scoreSO.Value;
        // TODO: change scene to EndQuestScene
        SceneManager.LoadSceneAsync("EndQuestScene");
    }
}
