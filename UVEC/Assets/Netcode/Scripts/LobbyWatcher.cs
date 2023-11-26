using System;
using System.Linq;
using ExitGames.Client.Photon.StructWrapping;
using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyWatcher : NetworkBehaviour
{
    public void Awake() => Runner ??= GetComponent<NetworkRunner>();

    [Flags]
    private enum FilledSlots
    {
        NONE = 0,
        RED = 1,
        GREEN = 2,
        BLUE = 4
    }

    private string[] playerTags = new string[3]
    {
        "p1",
        "p2",
        "p3"
    };
    
    private FilledSlots filledSlots = 0;
    
    public override void FixedUpdateNetwork()
    {
        // if (!Runner.IsSharedModeMasterClient)
        //     return;

        if (Runner.ActivePlayers.Count() != 3)
            return;
        
        if(SceneManager.GetActiveScene().name!= "LobbyScene")
            return;

        int i = 0;
        using (var activePlayers = Runner.ActivePlayers.GetEnumerator())
        {
            Runner.TryGetPlayerObject(activePlayers.Current, out var playerNetObject);
            
            if(playerNetObject.gameObject.CompareTag(playerTags[i]))
                filledSlots |= FilledSlots.RED;
            else if(playerNetObject.gameObject.CompareTag(playerTags[i+1]))
                filledSlots |= FilledSlots.GREEN;
            else if(playerNetObject.gameObject.CompareTag(playerTags[i+2]))
                filledSlots |= FilledSlots.BLUE;
        }
        
        if (filledSlots == FilledSlots.RED | filledSlots == FilledSlots.GREEN | filledSlots == FilledSlots.BLUE)
        {
            SceneManager.LoadScene("GameScene");
        }
        
    }
    
    
    
}
