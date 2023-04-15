using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndGameManager : MonoBehaviour
{
    //   will showcase score and time for 5 second, on update count down go back to home world scene
    public float timeLeft = 5.0f;
    public FloatSO scoreSO;
    public FloatSO timeSO;
    public Text allText;
    public ScoreboardManager scoreboardManager;

    void Start()
    {
        print("end game manager from end quest scene ");
        print("Score: " + scoreSO.Value);
        print("Time: " + timeSO.Value);


        
        allText.text = "Score: " + scoreSO.Value + " Time: " + timeSO.Value;
        // update with scoreboardManager
        scoreboardManager.AddScore(new Score("Player 1", scoreSO.Value, timeSO.Value));
        // add will go back to home world scene
        allText.text += " Will go back to home world scene in 5 seconds";
        SetToState();
    }

    void Update()
    {
        // yield return new WaitForSeconds(5);
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            print("Time: " + timeLeft);
            // TODO: save game
            SceneManager.LoadScene("HomeWorld");
        }
    }

    void SetToState()
    {   
        // weird bug, score and time is doubled
        State.Instance.score += (int)scoreSO.Value;
        State.Instance.time += timeSO.Value;
        
        // give 10000 currency for now
        State.Instance.currency += 10000;
    }

}
