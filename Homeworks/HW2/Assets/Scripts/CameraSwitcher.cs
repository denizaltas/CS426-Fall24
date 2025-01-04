using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera FPSCamera;   // Assign the player camera
    public Camera overheadCamera; // Assign the overhead camera

    private bool isOverheadView = false;

    void Start()
    {
        // Ensure only the Player Camera is active at the start
        FPSCamera.enabled = true;
        overheadCamera.enabled = false;
    }

    void Update()
    {
        // Switch cameras when pressing the "C" key
        if (Input.GetKeyDown(KeyCode.C))
        {
            isOverheadView = !isOverheadView;

            FPSCamera.enabled = !isOverheadView;
            overheadCamera.enabled = isOverheadView;

            Debug.Log(isOverheadView ? "Switched to Overhead Camera" : "Switched to Player Camera");
        }
    }
}
