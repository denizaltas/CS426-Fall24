using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;
    public float mouseSensitivity = 2f;

    [Header("Camera Settings")]
    public Camera FPSCamera;

    private float verticalRotation = 0f;
    private Rigidbody rb;

    void Start()
    {
        // Lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Ensure Rigidbody is present
        rb = GetComponent<Rigidbody>();
        
        rb.freezeRotation = true; // Prevent unwanted rotation from physics
    }

    void Update()
    {
        HandleMouseLook();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        // Rotate the camera vertically (up/down)
        FPSCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // Rotate the player horizontally (left/right)
        transform.Rotate(Vector3.up * mouseX);
    }

    private void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 moveDirection = (transform.forward * moveVertical + transform.right * moveHorizontal).normalized;

        // Move the player using Rigidbody
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
    }
}
