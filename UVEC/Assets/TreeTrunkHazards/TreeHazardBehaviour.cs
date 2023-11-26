using UnityEngine;

public class TreeHazardBehaviour : MonoBehaviour
{
	[SerializeField] private float _speed = 10f;
	[SerializeField] private float _highestAngle = 65f;
	[Tooltip("The direction the tree will move on start. Only the sign of this value is used.")]
	[SerializeField] private float _startingDirection = -1f;
	
	private float _direction;
	private void Start()
	{
		_direction = _startingDirection / Mathf.Abs(_startingDirection);
	}

	private void Update()
	{
		transform.Rotate(0f, 0f, Time.deltaTime * _speed * _direction);
		float relevantZrot =
			Mathf.Abs(transform.rotation.eulerAngles.z > 180 ? 360 - transform.rotation.eulerAngles.z : transform.rotation.eulerAngles.z);
		if (relevantZrot >= _highestAngle)
		{
			_direction = -_direction;
			transform.Rotate(0f, 0f, Time.deltaTime * _speed * _direction);
		}
	}
}
