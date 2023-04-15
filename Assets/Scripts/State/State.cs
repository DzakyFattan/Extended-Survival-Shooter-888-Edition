using UnityEngine;
using System.Collections.Generic;

public class State : MonoBehaviour, IDataPersistence
{
    public static State Instance; 

    // Declare all state variables here

    public float score = 0;
    public List<int> completedQuests = new List<int>();
    public List<int> ownedPets = new List<int>();
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
        this.score = data.score;
        this.completedQuests = data.completedQuests;
        this.ownedPets = data.ownedPets;
        this.boughtSword = data.boughtSword;
        this.boughtShotgun = data.boughtShotgun;
        this.boughtBow = data.boughtBow;
    }

    public void SaveData(ref GameData data)
    {
        // save data from this script into gameData
        data.score = this.score;
        data.completedQuests = this.completedQuests;
        data.ownedPets = this.ownedPets;
        data.boughtSword = this.boughtSword;
        data.boughtShotgun = this.boughtShotgun;
        data.boughtBow = this.boughtBow;
    }
}
