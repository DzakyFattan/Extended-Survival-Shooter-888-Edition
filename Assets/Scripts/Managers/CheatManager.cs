using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatManager : MonoBehaviour
{
    public string cheatNoDamage;
    public string cheatOneHit;
    public string cheatMotherlode;
    public string cheatTwoSpeed;
    public string cheatPetFull;
    public string cheatKillPet;
    public string cheatReset;

    public bool enteringCheat = false;
    public bool isCheatEnabled = false;
    private string EnteredString = "";
    public PlayerHealth playerHealth;
    public bool isOneHitEnabled = false;
    public bool isFullHPPetEnabled = false;

    public bool isKillAllPetsEnabled = false;
    public PlayerMovement playerMovement;

    private List<string> cheatList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        cheatList.Add(cheatNoDamage);
        cheatList.Add(cheatOneHit);
        cheatList.Add(cheatMotherlode);
        cheatList.Add(cheatTwoSpeed);
        cheatList.Add(cheatPetFull);
        cheatList.Add(cheatKillPet);
        cheatList.Add(cheatReset);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash) && !enteringCheat)
        {
            enteringCheat = true;

        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            enteringCheat = false;
            Debug.Log("Entered String: " + EnteredString);
            if (cheatList.Contains(EnteredString))
            {
                startCheat();
                isCheatEnabled = true;
            }
            else
            {
                Debug.Log("Cheat Not Found");
            }
            EnteredString = "";
        }
        else
        {
            if (enteringCheat)
            {
                if (Input.anyKeyDown)
                {
                    EnteredString += Input.inputString;
                }
            }
        }
    }

    private void startCheat()
    {
        if (EnteredString == cheatNoDamage)
        {
            playerHealth.isNoDamageEnabled = true;
        }
        else if (EnteredString == cheatOneHit)
        {
            isOneHitEnabled = true;
        }
        else if (EnteredString == cheatMotherlode)
        {
            Debug.Log(State.Instance.currency);
            State.Instance.currency += 2147483640;
            Debug.Log(State.Instance.currency);
        }
        else if (EnteredString == cheatTwoSpeed)
        {
            Debug.Log(playerMovement.speed);
            playerMovement.speed *= 2;
            Debug.Log(playerMovement.speed);
        }
        else if (EnteredString == cheatPetFull)
        {
            isFullHPPetEnabled = true;
        }
        else if (EnteredString == cheatKillPet)
        {
            isKillAllPetsEnabled = true;
        }
        else if (EnteredString == cheatReset && isCheatEnabled)
        {
            playerHealth.isNoDamageEnabled = false;
            isOneHitEnabled = false;
            State.Instance.currency -= 2147483640;
            playerMovement.speed = 6;
            isFullHPPetEnabled = false;
            isKillAllPetsEnabled = false;
            isCheatEnabled = false;
        }
    }
}
