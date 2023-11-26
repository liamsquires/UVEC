using UnityEngine;

public class CameraMaskManager : MonoBehaviour
{
	[SerializeField] private PlayerColor _playerColor;
	[SerializeField] private Camera _camera;

	private int _defaultLayer;
	private int _redLayer;
	private int _blueLayer;
	private int _greenLayer;

	private void Start()
	{
		_defaultLayer = LayerMask.NameToLayer("Default");
		_redLayer = LayerMask.NameToLayer("RedPlayer");
		_blueLayer = LayerMask.NameToLayer("BluePlayer");
		_greenLayer = LayerMask.NameToLayer("GreenPlayer");
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			ChangeMaskByColor();
	}

	private void ChangeMaskByColor()
	{
		switch (_playerColor)
		{
			case PlayerColor.RED:
				_camera.cullingMask = (1 << _blueLayer) | (1 << _greenLayer) | (1 << _defaultLayer);
				break;
			case PlayerColor.BLUE:
				_camera.cullingMask = (1 << _redLayer) | (1 << _greenLayer) | (1 << _defaultLayer);;
				break;
			case PlayerColor.GREEN:
				_camera.cullingMask = (1 << _blueLayer) | (1 << _redLayer) | (1 << _defaultLayer);;
				break;
		}
	}
}

public enum PlayerColor
{
	RED,
	BLUE,
	GREEN
}
