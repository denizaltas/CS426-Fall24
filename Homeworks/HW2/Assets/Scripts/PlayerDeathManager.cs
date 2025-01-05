using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerDeathManager : MonoBehaviour
{
    private bool isDead = false; // Prevent multiple death calls

    public void Die(string reason)
    {
        if (isDead) return; // Prevent multiple triggers

        isDead = true;

        // Disable Collider to prevent further triggers
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        StartCoroutine(LoadGameOverScene());
    }

    IEnumerator LoadGameOverScene()
    {
        Time.timeScale = 1f; // Ensure time is running normally
        yield return new WaitForSecondsRealtime(0f);

        SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
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

        // Death by Guard
        if (other.CompareTag("Guard"))
        {
            Die("Caught by a guard");
        }
    }

    void Update()
    {
        if (isDead) return; // Prevent further checks after death
    }
}
