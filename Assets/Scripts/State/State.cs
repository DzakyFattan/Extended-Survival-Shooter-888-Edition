using UnityEngine;
using System.Collections.Generic;

public class State : MonoBehaviour
{
    public static State Instance; 

    // Declare all state variables here

    public int score = 0;
    public int currency = 0;
    public string playerName = "Player X";
    public List<int> completedQuests = new List<int>();
    public List<int> ownedPets = new List<int>();
    public float time = 0;
    
    public ScoreData scoreData = new ScoreData();



    public bool boughtSword = false;
    public bool boughtShotgun = false;
    public bool boughtBow = false;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}