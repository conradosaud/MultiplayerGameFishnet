using UnityEngine;
using FishNet.Object;
using FishNet.Connection;
using TMPro;
using FishNet.Broadcast;
using FishNet;
using FishNet.Demo.AdditiveScenes;
using FishNet.Managing.Server;

public class Placar : NetworkBehaviour
{

    private TextMeshProUGUI _textMeshProGui;
    private readonly string _playerPrefix = "[PLAYER] ";

    private void Awake()
    {
        _textMeshProGui = GameObject.Find("Canvas").transform.Find("Placar").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        UpdatePlayerList();
    }


    private void UpdatePlayerList()
    {
        string playerListText = "";

        // Loop through all players
        foreach (var player in ClientManager.Clients)
        {
            // Add player ID to the list
            playerListText += _playerPrefix + player.Key + "\n";
        }

        // Update the text in the TextMeshProUGUI
        _textMeshProGui.text = playerListText;


    }


}
