using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscortQuestManager : MonoBehaviour
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
    }

    public void EndGame(){
        endTime = Time.time;
        timeSO.Value += endTime - startTime;
        // print("Time: " + (endTime - startTime).ToString());
        State.Instance.completedQuests.Add(3);
        // TODO: change scene to EndQuestScene
        SceneManager.LoadScene("EndQuestScene");
    }
}
