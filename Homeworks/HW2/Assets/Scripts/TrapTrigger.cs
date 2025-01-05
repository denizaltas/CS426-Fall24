using UnityEngine;
using System.Collections;

public class TrapTrigger : MonoBehaviour
{
    [Header("Trap Settings")]
    public float activeDuration = 3f; // Time the trap stays active
    public float inactiveDuration = 5f; // Time the trap stays inactive

    public TrapVisuals trapVisuals; // Reference to the TrapVisuals script
    public Collider triggerZone; // Reference to the Trigger Zone Collider

    private bool isActive = false;
    public bool IsActive => isActive;


    void Start()
    {
        if (triggerZone == null)
        {
            triggerZone = GetComponent<Collider>();
        }

        if (trapVisuals == null)
        {
            trapVisuals = GetComponentInChildren<TrapVisuals>();
        }

        StartCoroutine(TrapCycle());
    }

    void UpdateTrapState(bool state)
    {
        isActive = state;
        triggerZone.enabled = state; // Enable/Disable trigger collider

        if (trapVisuals != null)
        {
            trapVisuals.SetTrapActive(state); // Update visuals
        }
    }

    IEnumerator TrapCycle()
    {
        while (true)
        {
            // Activate the trap
            UpdateTrapState(true);
            yield return new WaitForSeconds(activeDuration);

            // Deactivate the trap
            UpdateTrapState(false);
            yield return new WaitForSeconds(inactiveDuration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActive && other.CompareTag("Player"))
        {
            HandlePlayerDeath(other.gameObject);
        }
    }

    void HandlePlayerDeath(GameObject player)
    {
        PlayerMovement controller = player.GetComponent<PlayerMovement>();
        if (controller != null)
        {
            controller.enabled = false;
        }
    }
}
