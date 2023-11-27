using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static List<TestPlayerController> Players;

	private List<TestPlayerController> _deadPlayers;

	public GameObject explosionVFX;
	private void OnEnable()
	{
		_deadPlayers = new List<TestPlayerController>();
		Debug.Log("OnEnable");
		foreach (TestPlayerController player in Players)
		{
			Debug.Log("Registering Event");
			player.Died += PlayerDied;
		}
	}

	private void OnDisable()
	{
		foreach (TestPlayerController player in Players)
		{
			player.Died -= PlayerDied;
		}
	}

	private void PlayerDied(TestPlayerController obj)
	{
		Debug.Log(obj);
		
		Instantiate(explosionVFX, obj.transform.position, Quaternion.identity);
		
		if(!_deadPlayers.Contains(obj))
			_deadPlayers.Add(obj);
		if (_deadPlayers.Count == Players.Count)
		{
			Debug.Log("Everyone died");
		}
	}

	public void QuitApplication()
	{
		Application.Quit();
	}

	public void ReturnToMainMenu()
	{
		
	}

	public void RestartGame()
	{
		
	}
}
