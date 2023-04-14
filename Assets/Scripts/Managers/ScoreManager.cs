using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;

    public FloatSO scoreSO;

    public Text text;


    void Awake ()
    {
        text = GetComponent <Text> ();
        score = 0;
    }


    void Update ()
    {
        text.text = "Score: " + score;
        // TODO: update scoreSO
        scoreSO.Value = score;
        // TODO: for quest 1 if score is 100, load EndQuestScene
    }
}
