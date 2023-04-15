using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstQuestManager : MonoBehaviour
{
    // public score SO
    public FloatSO scoreSO;
    public FloatSO timeSO;


    float startTime;
    float endTime;
    
    void Awake(){
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // check sore SO. if it hits 100, call endgame
        if(scoreSO.Value >= 100f){
            this.EndGame();
        }
    }
    void EndGame(){
        endTime = Time.time;
        timeSO.Value += endTime - startTime;
        print("Time: " + (endTime - startTime).ToString());
        // TODO: change scene to EndQuestScene
        SceneManager.LoadScene("EndQuestScene");
    }
}
