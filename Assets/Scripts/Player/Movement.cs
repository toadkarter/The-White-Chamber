using UnityEngine;

// Source: https://www.youtube.com/watch?v=_QajrabyTJc&t=853s
public class Movement : MonoBehaviour
{
    private CharacterController _playerBody = null;
    private Camera _playerCamera = null;
    private float _xRotation = 0f;
    private bool _canMove = true;

    public bool CanMove => _canMove;

    [SerializeField] private float speed = 12f;
    [SerializeField] private float mouseSensitivity = 100f;
    
    private void Start()
    {
        _playerBody = GetComponent<CharacterController>();
        _playerCamera = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MoveAndLook()
    {
        if (!_canMove) return;
        Move();
        Look();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        var direction = transform.right * x + transform.forward * z;
        _playerBody.Move(direction * speed * Time.deltaTime);
    }

    private void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        _playerCamera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        _playerBody.transform.Rotate(Vector3.up * mouseX);
    }

    public Item GetObjectBeingLookedAt()
    {
        var ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
        return !Physics.Raycast(ray, out var hit) ? null : hit.transform.GetComponent<Item>();
    }

    public void SetCanMove(bool canMove)
    {
        if (canMove)
        {
            Cursor.lockState = CursorLockMode.Locked;
            _canMove = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            _canMove = false;
        }
    }
}
