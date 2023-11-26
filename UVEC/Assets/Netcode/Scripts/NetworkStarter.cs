using System;
using System.Collections;
using System.Threading.Tasks;
using Fusion;
using Fusion.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkStarter: Fusion.Behaviour
{
    public GameObject RunnerPrefab;
    public TMP_Text LoadingText;

    public bool skipMenu;
    
    private void Start()
    {
        RunnerPrefab = Instantiate(RunnerPrefab);
        DontDestroyOnLoad(RunnerPrefab);
        
        if(skipMenu)
            Join();
    }
    
    public void Join()
    {
        StartCoroutine(StartShared());
        LoadingText.gameObject.SetActive(true);
    }

    private IEnumerator StartShared()
    {
        var runner = RunnerPrefab.GetComponent<NetworkRunner>();
        var sceneManager = RunnerPrefab.GetComponent<NetworkSceneManagerDefault>();
            
        var gameArgs = new StartGameArgs
        {
            GameMode = GameMode.Shared,
            Address = NetAddress.Any(),
            SessionName = "UVECssn",
            SceneManager = sceneManager
        };
        
        Task clientTask = runner.StartGame(gameArgs);
        yield return new WaitForSeconds(1f);
        
        while (clientTask.IsCompleted == false) {
            yield return new WaitForSeconds(1f);
        }
        
        if (clientTask.IsFaulted) {
            Debug.LogWarning(clientTask.Exception);
        }
        
        LoadingText.gameObject.SetActive(false);
        SceneManager.LoadScene("Prototype");
    }
}
