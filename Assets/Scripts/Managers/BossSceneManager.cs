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
        Score score = new Score(State.Instance.playerName, State.Instance.score, State.Instance.time);
        scoreboardManager.AddScore(score);
        SceneManager.LoadScene("EndingScene");
    }
}
