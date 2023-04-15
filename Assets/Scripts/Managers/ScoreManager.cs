using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{

    public FloatSO scoreSO;

    public Text text;


    void Awake ()
    {
        text = GetComponent <Text> ();
    }


    void Update ()
    {
        text.text = "Score: " + scoreSO.Value;
        // TODO: update scoreSO
        // TODO: for quest 1 if score is 100, load EndQuestScene
    }
}
