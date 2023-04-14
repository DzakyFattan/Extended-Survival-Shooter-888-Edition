using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    [SerializeField]
    Transform[] petPositions;

    [SerializeField]
    GameObject[] petPrefabs;

    private GameObject[] activePets;

    private bool chaseMode = false;
    private int buffDamage = 0;
    // public event EventHandler killAllPets;

    // Start is called before the first frame update
    void Start()
    {
        activePets = new GameObject[petPositions.Length];
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn pet based on number pressed
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (!State.Instance.ownedPets.Contains(0))
            {
                print("You don't have this pet yet!");
                return;
            }
            SpawnPet(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (!State.Instance.ownedPets.Contains(1))
            {
                print("You don't have this pet yet!");
                return;
            }
            SpawnPet(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (!State.Instance.ownedPets.Contains(2))
            {
                print("You don't have this pet yet!");
                return;
            }
            SpawnPet(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            KillAllPets();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeMode();
        }
    }

    void SpawnPet(int petIndex)
    {
        // Find first available pet position
        for (int i = 0; i < petPositions.Length; i++)
        {
            if (activePets[i] == null)
            {
                // Spawn pet
                activePets[i] = Instantiate(petPrefabs[petIndex], petPositions[i].position, petPositions[i].rotation);
                activePets[i].GetComponent<PetMovement>().setTarget(petPositions[i]);
                break;
            }
        }
    }

    public bool AvailableSlot()
    {
        for (int i = 0; i < petPositions.Length; i++)
        {
            if (activePets[i] == null)
            {
                return true;
            }
        }
        return false;
    }

    public void KillAllPets()
    {
        for (int i = 0; i < petPositions.Length; i++)
        {
            if (activePets[i] != null)
            {
                activePets[i].GetComponent<PetHealth>().Death();
            }
        }
    }

    public void ChangeMode()
    {
        chaseMode = !chaseMode;
        for (int i = 0; i < petPositions.Length; i++)
        {
            if (activePets[i] != null)
            {
                // Check which prefab this pet is
                activePets[i].GetComponent<PetMovement>().ChangeMode(chaseMode);
            }
        }
    }

    public int getBuffDamage()
    {
        return buffDamage;
    }

    public void updateBuffDamage(int amount)
    {
        buffDamage += amount;
    }
}
