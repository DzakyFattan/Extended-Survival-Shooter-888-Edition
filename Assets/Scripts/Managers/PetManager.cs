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
    // Start is called before the first frame update
    void Start()
    {
        activePets = new GameObject[petPositions.Length];
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn pet based on number pressed

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnPet(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnPet(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnPet(2);
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
}
