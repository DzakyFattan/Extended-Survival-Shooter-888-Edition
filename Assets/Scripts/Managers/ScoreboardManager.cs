using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardManager : MonoBehaviour
{
    // private static GameObject Instance;
    private ScoreData scoreData;

    void Awake()
    {
        PlayerPrefs.DeleteAll();
        var json = PlayerPrefs.GetString("ScoreData", "{}");
        scoreData = JsonUtility.FromJson<ScoreData>(json);
    }
    void Start()
    {
        Debug.Log("ScoreBoardManager");
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
        Debug.Log("ScoreboardManager OnDestroy");
        SaveScoreData();
    }

    public void SaveScoreData()
    {
        string json = JsonUtility.ToJson(scoreData);
        PlayerPrefs.SetString("ScoreData", json);
    }
}
