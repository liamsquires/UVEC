using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public List<PlayerController> Players;

	private List<PlayerController> _deadPlayers;

	private void OnEnable()
	{
		_deadPlayers = new List<PlayerController>();
		Debug.Log("OnEnable");
		foreach (PlayerController player in Players)
		{
			Debug.Log("Registering Event");
			player.Died += PlayerDied;
		}
	}

	private void OnDisable()
	{
		foreach (PlayerController player in Players)
		{
			player.Died -= PlayerDied;
		}
	}

	private void PlayerDied(PlayerController obj)
	{
		Debug.Log(obj);
		if(!_deadPlayers.Contains(obj))
			_deadPlayers.Add(obj);
		if (_deadPlayers.Count == Players.Count)
		{
			Debug.Log("Everyone died");
		}
	}
}
