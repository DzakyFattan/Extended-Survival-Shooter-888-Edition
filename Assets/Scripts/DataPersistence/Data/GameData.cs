using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string lastUpdated;
    public string playerName;
    public float score;
    public List<int> completedQuests;
    public List<int> ownedPets;
    public bool boughtSword;
    public bool boughtShotgun;
    public bool boughtBow;

    public GameData()
    {
        this.playerName = "Player1";
        this.score = 0;
        this.completedQuests = new List<int>();
        this.ownedPets = new List<int>();
        this.boughtSword = false;
        this.boughtShotgun = false;
        this.boughtBow = false;
    }
}
