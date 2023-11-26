using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class CanDie : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    private void Start()
    {
        if (_playerController == null)
        {
            _playerController = GetComponent<PlayerController>();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeathBox"))
        {
            _playerController.Die();
        }
    }
}
