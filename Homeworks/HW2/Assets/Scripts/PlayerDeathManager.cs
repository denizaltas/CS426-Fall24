using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathManager : MonoBehaviour
{
    private bool isDead = false; // Prevent multiple death calls

    public void Die(string reason)
    {
        if (isDead) return; // Prevent multiple triggers

        isDead = true;

        // Disable Player Movement
        PlayerMovement controller = GetComponent<PlayerMovement>();
        if (controller != null)
        {
            controller.enabled = false;
        }

        // Disable Collider to prevent further triggers
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        Invoke(nameof(LoadGameOverScene), 1.5f);
    }

    void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    void OnTriggerEnter(Collider other)
    {
        if (isDead) return; // Prevent processing if already dead

        // Death by Falling
        if (other.CompareTag("DeathZone"))
        {
            Die("Fell from the platform");
        }

        // Death by Trap
        TrapTrigger trap = other.GetComponent<TrapTrigger>();
        if (trap != null && trap.IsActive)
        {
            Die("Caught by a trap");
        }

    }

    void Update()
    {
        if (isDead) return; // Prevent further checks after death
    }
}
