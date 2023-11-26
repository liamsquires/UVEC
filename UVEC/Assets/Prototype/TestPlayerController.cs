using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _rotateSpeed = 50f;
    [SerializeField] private float _lookUpDownSpeed = 20f;
     public Camera _camera;
    [SerializeField] private float camUpMax = 130f;
    [SerializeField] private float camDownMax = 70f;
    
    
    
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * _speed;
        }
        
        transform.Rotate(0f, Input.GetAxis("Mouse X") * _rotateSpeed * Time.deltaTime, 0f);
        _camera.transform.Rotate(-Input.GetAxis("Mouse Y") * _lookUpDownSpeed * Time.deltaTime, 0f, 0f);
    }
}
