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
        scoreManager.AddScore(new Score("Player", 100, 10));
        var scores = scoreManager.GetScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var score = scores[i];
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.nameText.text = score.name;
            row.timeText.text = score.time.ToString();
        }
    }
}
