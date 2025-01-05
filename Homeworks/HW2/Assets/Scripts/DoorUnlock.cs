using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class DoorUnlock : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float unlockRange = 2.0f; // Distance within which the door can be unlocked
    public Renderer doorRenderer; // Reference to the door's Renderer for color change

    private bool isUnlocked = false; // To track if the door is unlocked

    void Start()
    {
        if (doorRenderer == null)
        {
            doorRenderer = GetComponent<Renderer>();
        }
    }

    void Update()
    {
        if (!isUnlocked && Vector3.Distance(transform.position, player.position) <= unlockRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && PlayerHasKey())
            {
                UnlockDoor();
            }
        }
    }

    bool PlayerHasKey()
    {
        // Check if the player is carrying the key
        KeyPickup keyPickup = player.GetComponentInChildren<KeyPickup>();
        return keyPickup != null && keyPickup.transform.parent == player;
    }

    void UnlockDoor()
    {
        if (isUnlocked) return; // Prevent repeated unlocks

        isUnlocked = true;
        doorRenderer.material.color = Color.black; // Change door color to black

        // Make door a trigger after unlocking
        Collider doorCollider = GetComponent<Collider>();
        if (doorCollider != null)
        {
            doorCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (isUnlocked && other.CompareTag("Player"))
        {
            EndGame();
        }
    }

    void EndGame()
    {
        SceneManager.LoadScene("GameCompleteScene");
    }
}
