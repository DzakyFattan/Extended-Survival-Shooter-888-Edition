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
    
    void Start()
    {
        print("Score: " + scoreSO.Value);
        print("Time: " + timeSO.Value);
        allText.text = "Score: " + scoreSO.Value + " Time: " + timeSO.Value;
        // add will go back to home world scene
        allText.text += " Will go back to home world scene in 5 seconds";
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            print("Time: " + timeLeft);
            // TODO: save game
            // DataPersistenceManager.instance.SaveGame();
            SceneManager.LoadSceneAsync("HomeWorld");
        }
    }

}
