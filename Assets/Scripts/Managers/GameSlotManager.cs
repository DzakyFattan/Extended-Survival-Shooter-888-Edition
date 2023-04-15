using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSlotManager : MonoBehaviour
{
    private GameSlot[] gameSlots;

    private void Awake()
    {
        gameSlots = GetComponentsInChildren<GameSlot>();
    }

    public void OnGameSlotClicked(GameSlot gameSlot)
    {
        DataPersistenceManager.instance.ChangeSelectedProfileId(gameSlot.GetProfileId());
        DataPersistenceManager.instance.LoadGame();
        SceneManager.LoadScene("HomeWorld");
    }

    private void Start()
    {
        ActivateMenu();
    }

    public void ActivateMenu()
    {
        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.instance.GetAllProfilesGameData();
        foreach (GameSlot gameSlot in gameSlots)
        {
            GameData profileData = null;
            profilesGameData.TryGetValue(gameSlot.GetProfileId(), out profileData);
            gameSlot.SetData(profileData);
            if (profileData == null)
            {
                // set gameslot's button component interactable to false
                gameSlot.SetInteractable(false);
            }
            else
            {
                // set gameslot's button component interactable to true
                gameSlot.SetInteractable(true);
            }
        }
    }
}
