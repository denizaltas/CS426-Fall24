using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    private float verticalRotation = 0f;

    public Camera FPSCamera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen
        Cursor.visible = false; // Hide cursor
    }

    void Update()
    {

        // Handle Mouse Look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        FPSCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * moveVertical + transform.right * moveHorizontal;
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
