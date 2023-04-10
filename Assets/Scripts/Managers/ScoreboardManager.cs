using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardManager : MonoBehaviour
{
    private ScoreData scoreData;

    void Awake()
    {
        var json = PlayerPrefs.GetString("ScoreData", "{}");
        scoreData = JsonUtility.FromJson<ScoreData>(json);
    }

    public IEnumerable<Score> GetScores()
    {
        return scoreData.scores.OrderByDescending(s => s.score);
    }

    public void AddScore(Score score)
    {
        scoreData.scores.Add(score);
    }

    private void OnDestroy()
    {
        SaveScoreData();
    }

    public void SaveScoreData()
    {
        string json = JsonUtility.ToJson(scoreData);
        PlayerPrefs.SetString("ScoreData", json);
    }
}
