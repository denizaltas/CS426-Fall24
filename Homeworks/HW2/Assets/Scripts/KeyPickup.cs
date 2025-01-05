using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float pickupRange = 2.0f; // Distance within which the key can be picked up
    private bool isPickedUp = false; // To check if the key is already picked up
    private Rigidbody rb; // Rigidbody for physics interactions

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isPickedUp && Vector3.Distance(transform.position, player.position) <= pickupRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUpKey();
            }
        }

        if (isPickedUp)
        {
            CarryKey();

            if (Input.GetKeyDown(KeyCode.F))
            {
                DropKey();
            }
        }
    }

    void PickUpKey()
    {
        isPickedUp = true;
        rb.isKinematic = true; // Disable physics while carrying
        transform.SetParent(player); // Attach key to the player
        transform.localPosition = new Vector3(0, 1.5f, 1); // Position key relative to player
        Debug.Log("Key Picked Up!");
    }

    void CarryKey()
    {
        // Ensures the key follows the player smoothly
        transform.position = player.position + player.forward * 1.0f + Vector3.up * 1.5f;
    }

    public void DropKey()
    {
        isPickedUp = false;
        rb.isKinematic = false; // Re-enable physics
        transform.SetParent(null); // Detach from player
        Debug.Log("Key Dropped!");
    }
}
