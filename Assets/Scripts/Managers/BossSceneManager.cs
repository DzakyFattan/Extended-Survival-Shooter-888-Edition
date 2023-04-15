using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSceneManager : MonoBehaviour
{
    // public score SO
    public FloatSO scoreSO;
    public FloatSO timeSO;
    public ScoreboardManager scoreboardManager;


    float startTime;
    float endTime;
    
    void Awake(){
        startTime = Time.time;
    }

    public void EndGame(){
        endTime = Time.time;
        timeSO.Value += endTime - startTime;
        // print("Time: " + (endTime - startTime).ToString());
        Score score = new Score("Player1", 1, 1);
        scoreboardManager.AddScore(score);
        SceneManager.LoadScene("EndingScene");
    }
}
