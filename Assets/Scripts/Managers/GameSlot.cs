using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSlot : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] private string profileId = "";

    [Header("Content")]
    [SerializeField] private GameObject noDataContent;
    [SerializeField] private GameObject hasDataContent;
    [SerializeField] private Text playerNameText;
    [SerializeField] private Text lastUpdatedText;

    public Button button;

    public void SetData(GameData data)
    {
        button = GetComponent<Button>();
        if (data == null)
        {
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
        }
        else
        {
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);

            playerNameText.text = data.playerName;
            lastUpdatedText.text = data.lastUpdated;
        }
    }

    public string GetProfileId()
    {
        return profileId;
    }
}
