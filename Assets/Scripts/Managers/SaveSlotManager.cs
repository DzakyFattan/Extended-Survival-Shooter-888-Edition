using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSlotManager : MonoBehaviour
{
    private GameSlot[] gameSlots;
    public GameObject saveCanvas;

    private void Awake()
    {
        gameSlots = GetComponentsInChildren<GameSlot>();
    }

    public void OnGameSlotClicked(GameSlot gameSlot)
    {
        Debug.Log("SaveSlotManager.OnGameSlotClicked() called");
        DataPersistenceManager.instance.ChangeSelectedProfileId(gameSlot.GetProfileId());
        DataPersistenceManager.instance.SaveGame();
        saveCanvas.SetActive(false);
        // enable mouse lock
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        ActivateMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            saveCanvas.SetActive(false);
            // enable mouse lock
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void ActivateMenu()
    {
        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.instance.GetAllProfilesGameData();
        foreach (GameSlot gameSlot in gameSlots)
        {
            GameData profileData = null;
            profilesGameData.TryGetValue(gameSlot.GetProfileId(), out profileData);
            gameSlot.SetData(profileData);
        }
    }
}
