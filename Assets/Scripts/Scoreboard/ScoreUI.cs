using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUI;
    public ScoreboardManager scoreManager;
    void Start()
    {
        ScoreData scoreData = State.Instance.scoreData;
        for (int i = 0; i < scoreData.scores.Count; i++)
        {
            var score = scoreData.scores[i];
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.nameText.text = score.name;
            row.timeText.text = score.time.ToString();
        }
        // var scores = scoreManager.GetScores().ToArray();
        // for (int i = 0; i < scores.Length; i++)
        // {
        //     var score = scores[i];
        //     var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
        //     row.nameText.text = score.name;
        //     row.timeText.text = score.time.ToString();
        // }
    }
}
