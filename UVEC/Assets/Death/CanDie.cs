using UnityEngine;

[RequireComponent(typeof(TestPlayerController))]
public class CanDie : MonoBehaviour
{
    [SerializeField] private TestPlayerController _testPlayerController;

    private void Start()
    {
        if (_testPlayerController == null)
        {
            _testPlayerController = GetComponent<TestPlayerController>();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeathBox"))
        {
            _testPlayerController.Die();
        }
    }
}
