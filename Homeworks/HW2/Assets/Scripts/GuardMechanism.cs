using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class GuardMechanism : MonoBehaviour
{
    [Header("Patrol Settings")]
    public Transform pointA; // Patrol point A
    public Transform pointB; // Patrol point B
    public float patrolSpeed = 2f; // Speed of movement
    public float waitTime = 3f; // Time to wait at each point

    [Header("Player Detection")]
    public float detectionRange = 1f; // Range to detect the player
    public LayerMask playerLayer; // Layer to detect the player

    private Transform currentTarget; // Current patrol target
    private Rigidbody rb;
    private bool isPlayerDetected = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentTarget = pointA; // Start by moving towards pointA
        StartCoroutine(Patrol());
    }

    void Update()
    {
        if (!isPlayerDetected)
        {
            DetectPlayer();
        }
    }

    IEnumerator Patrol()
    {
        while (!isPlayerDetected)
        {
            if (currentTarget == null) yield break;

            Vector3 direction = (currentTarget.position - transform.position).normalized;
            Vector3 newPosition = transform.position + direction * patrolSpeed * Time.fixedDeltaTime;

            // Move the guard using Rigidbody to respect physics
            rb.MovePosition(newPosition);

            // Check if guard reached the target point
            if (Vector3.Distance(transform.position, currentTarget.position) < 0.2f)
            {
                currentTarget = (currentTarget == pointA) ? pointB : pointA;
                yield return new WaitForSeconds(waitTime);
            }

            yield return null;
        }
    }

    void DetectPlayer()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange, playerLayer);

        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                Debug.Log("Player Detected by Guard! Triggering Game Over...");
                isPlayerDetected = true;
                StopCoroutine(Patrol());
                rb.velocity = Vector3.zero; // Stop the guard's movement
                TriggerGameOver();
            }
        }
    }

    void TriggerGameOver()
    {
        PlayerDeathManager playerDeath = FindObjectOfType<PlayerDeathManager>();
        if (playerDeath != null)
        {
            playerDeath.Die("Caught by a guard");
        }
    }

    void OnDrawGizmos()
    {
        // Visualize patrol path and detection range
        Gizmos.color = Color.green;
        if (pointA != null && pointB != null)
            Gizmos.DrawLine(pointA.position, pointB.position);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
