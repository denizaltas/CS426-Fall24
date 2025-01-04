using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    private bool isUnlocked = false; // Tracks if the door is unlocked
    private bool isPlayerThrough = false; // Prevent multiple triggers

    public TextMeshProUGUI interactionText; // UI Text for unlocking instructions
    public Renderer doorRenderer; // Renderer for visual feedback
    private Transform player; // Reference to the player object

    void Start()
    {
        if (interactionText != null)
            interactionText.gameObject.SetActive(false);

        if (doorRenderer == null)
            doorRenderer = GetComponent<Renderer>();

        // Find the player in the scene
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        HandleDoorProximity();
    }

    void HandleDoorProximity()
    {
        if (player == null || interactionText == null)
            return;

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= 2.0f)
        {
            if (!isUnlocked && KeyPickup.hasKey) // Access static hasKey from KeyPickup
            {
                interactionText.gameObject.SetActive(true);
                interactionText.text = "Press E to unlock the door";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    UnlockDoor();
                }
            }
            else if (!KeyPickup.hasKey)
            {
                interactionText.gameObject.SetActive(false); // Hide if player doesn't have the key
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false); // Hide interaction text if far away
        }
    }

    void UnlockDoor()
    {
        isUnlocked = true;

        if (interactionText != null)
            interactionText.gameObject.SetActive(false);

        if (doorRenderer != null)
        {
            // Change door color to black as visual feedback
            doorRenderer.material.color = Color.black;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isUnlocked && other.CompareTag("Player") && !isPlayerThrough)
        {
            isPlayerThrough = true;

            // Notify the GameManager
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.ShowLevelComplete();
            }
        }
    }
}
