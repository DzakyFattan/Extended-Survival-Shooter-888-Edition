using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardManager : MonoBehaviour
{
    private static GameObject Instance;
    private ScoreData scoreData;
    public Button backButton;
    public delegate void ButtonClicked();
    public static event ButtonClicked onBackButtonClicked;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log("Destroying duplicate ScoreboardManager");
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Setting ScoreboardManager");
            Instance = this.gameObject;
            // DontDestroyOnLoad(gameObject);
        }
        PlayerPrefs.DeleteAll();
        var json = PlayerPrefs.GetString("ScoreData", "{}");
        scoreData = JsonUtility.FromJson<ScoreData>(json);
    }
    void Start()
    {
        Debug.Log("ScoreBoardManager");
        Debug.Log(backButton);
        backButton.onClick.AddListener(BackToMainMenu);
    }
    public IEnumerable<Score> GetScores()
    {
        return scoreData.scores.OrderByDescending(s => s.score);
    }

    public void AddScore(Score score)
    {
        scoreData.scores.Add(score);
    }

    public void BackToMainMenu()
    {
        if (onBackButtonClicked != null)
        {
            onBackButtonClicked?.Invoke();
        }
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
