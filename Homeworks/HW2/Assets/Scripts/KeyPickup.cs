using UnityEngine;
using TMPro;

public class KeyPickup : MonoBehaviour
{
    public static bool hasKey = false; // Static variable to track if the key is picked up

    public TextMeshProUGUI interactionText; // Optional for UI feedback

    void Start()
    {
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (IsPlayerClose())
        {
            if (interactionText != null)
            {
                interactionText.gameObject.SetActive(true);
                interactionText.text = "Press E to pick up the key";
            }

            if (Input.GetKeyDown(KeyCode.E) && !hasKey)
            {
                PickUpKey();
            }
        }
        else if (interactionText != null)
        {
            interactionText.gameObject.SetActive(false);
        }
    }

    bool IsPlayerClose()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            return distance <= 2.0f;
        }
        return false;
    }

    void PickUpKey()
    {
        hasKey = true;
        gameObject.SetActive(false);

        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(false);
        }
    }
}
