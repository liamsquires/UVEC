using System.Collections.Generic;
using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState
{
    #region singleton

    private static GameState _instance;

    public static GameState Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameState();
            return _instance;
        }
    }

    public Dictionary<PlayerRef, NetworkObject> Players = new();
    // public Dictionary<PlayerRef, bool> PlayersReady = new();

    public void CheckAllReady()
    {
        Debug.Log("Called CheckAllReady");

        if (Object.FindObjectsOfType<Identity>().Length != 3)
        {
            Debug.Log("Not all players have joined yet");
            return;
        }


        foreach (Identity identity in Object.FindObjectsOfType<Identity>())
        {
            if (!identity.ready)
            {
                Debug.Log("Not all players are ready");
                return;
            }
        }


        Debug.Log("All players ready");
        
        foreach (LobbyPad pad in Object.FindObjectsOfType<LobbyPad>())
        {
            pad.gameObject.SetActive(false);
        }
        
        GameObject.FindWithTag("Floor").SetActive(false);
    }

    #endregion
}