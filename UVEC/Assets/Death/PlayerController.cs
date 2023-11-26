using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Action<PlayerController> Died;
    
	public void Die()
	{
		Debug.Log("Death awaits even the slightest lapse in concentration.");
		Died?.Invoke(this);
	}
}
