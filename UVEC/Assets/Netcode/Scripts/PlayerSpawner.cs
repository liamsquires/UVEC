using System;
using System.Collections.Generic;
using Fusion;
using Fusion.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : SimulationBehaviour, INetworkRunnerCallbacks
{
    [SerializeField] private NetworkObject PlayerPrefab;

    public void Awake() => Runner ??= GetComponent<NetworkRunner>();

    //scene loaded event subscription
    public void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
    public void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;
    // ---

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (SceneManager.GetActiveScene().name != "Prototype")
            return;
        
        var pObj = Runner.Spawn(PlayerPrefab, new Vector3(0,5,0), Quaternion.identity, inputAuthority:Runner.LocalPlayer);
        Runner.SetPlayerObject(Runner.LocalPlayer, pObj);
        GameState.Instance.Players[Runner.LocalPlayer] = pObj;
        //GameState.Instance.PlayersReady[Runner.LocalPlayer] = false;
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
    }

    #region INetworkRunnerCallbacks
    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {

    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
    }
    #endregion
}