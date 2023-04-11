using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        cheatNoDamage = new string[] { "b", "a", "g", "u", "v", "i", "x" };
        cheatOneHit = new string[] { "f", "u", "l", "l", "c", "l", "i", "p" };
        cheatMotherlode = new string[] { "h", "e", "s", "o", "y", "a", "m" };
        cheatTwoSpeed = new string[] { "i", "a", "m", "s", "p", "e", "e", "d" };
        cheatPetFull = new string[] { "p", "e", "t", "f", "u", "l", "l" };
        cheatKillPet = new string[] { "g", "e", "n", "o", "c", "i", "d", "e" };
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            if (Input.anyKeyDown)
            {
                if (InputGetKeyDown(cheatNoDamage[index]))
                {
                    index++;
                    if (index == cheatNoDamage.Length)
                    {
                        index = 0;
                        Debug.Log("No Damage");
                        // TODO: Add code to disable damage
                    }
                    else
                    {
                        index = 0;
                    }
                }
                else if (InputGetKeyDown(cheatOneHit[index]))
                {
                    index++;
                    if (index == cheatOneHit.Length)
                    {
                        index = 0;
                        Debug.Log("One Hit");
                        // TODO
                    }
                    else
                    {
                        index = 0;
                    }
                }
                else if (InputGetKeyDown(cheatMotherlode[index]))
                {
                    index++;
                    if (index == cheatMotherlode.Length)
                    {
                        index = 0;
                        Debug.Log("Motherlode");
                        // TODO
                    }
                    else
                    {
                        index = 0;
                    }
                }
                else if (InputGetKeyDown(cheatTwoSpeed[index]))
                {
                    index++;
                    if (index == cheatTwoSpeed.Length)
                    {
                        index = 0;
                        Debug.Log("Two Speed");
                        // TODO
                    }
                    else
                    {
                        index = 0;
                    }
                }
                else if (InputGetKeyDown(cheatPetFull[index]))
                {
                    index++;
                    if (index == cheatPetFull.Length)
                    {
                        index = 0;
                        Debug.Log("Pet Full");
                        // TODO
                    }
                    else
                    {
                        index = 0;
                    }
                }
                else if (InputGetKeyDown(cheatKillPet[index]))
                {
                    index++;
                    if (index == cheatKillPet.Length)
                    {
                        index = 0;
                        Debug.Log("Kill Pet");
                        // TODO
                    }
                    else
                    {
                        index = 0;
                    }
                }
                else
                {
                    index = 0;
                }
            }
        }
    }
}
