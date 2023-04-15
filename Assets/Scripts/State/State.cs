using UnityEngine;
using System.Collections.Generic;

public class State : MonoBehaviour, IDataPersistence
{
    public static State Instance;

    // Declare all state variables here
    public string playerName = "Player1";
    public float score = 0;
    public int currency;
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

    public void LoadData(GameData data)
    {
        // load data from gameData into this script
        this.playerName = data.playerName;
        this.score = data.score;
        this.currency = data.currency;
        this.completedQuests = data.completedQuests;
        this.ownedPets = data.ownedPets;
        this.boughtSword = data.boughtSword;
        this.boughtShotgun = data.boughtShotgun;
        this.boughtBow = data.boughtBow;
    }

    public void SaveData(ref GameData data)
    {
        // save data from this script into gameData
        data.playerName = this.playerName;
        data.score = this.score;
        data.currency = this.currency;
        data.completedQuests = this.completedQuests;
        data.ownedPets = this.ownedPets;
        data.boughtSword = this.boughtSword;
        data.boughtShotgun = this.boughtShotgun;
        data.boughtBow = this.boughtBow;
    }

    public void Reset()
    {
        // reset all state variables here
        // this.playerName = "Player1";
        this.score = 0;
        this.currency = 0;
        this.completedQuests = new List<int>();
        this.ownedPets = new List<int>();
        this.boughtSword = false;
        this.boughtShotgun = false;
        this.boughtBow = false;
    }
}
