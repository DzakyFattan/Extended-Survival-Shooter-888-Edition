using UnityEngine;
using System.Collections.Generic;

public class State : MonoBehaviour
{
    public static State Instance; 

    // Declare all state variables here

    public int score = 0;
    public HashSet<int> completedQuests = new HashSet<int>();
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
}