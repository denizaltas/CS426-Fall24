using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI instructionText; // WASD instructions
    public TextMeshProUGUI interactionText; // Door interaction prompts
    public TextMeshProUGUI completionText;  // Level completion message

    [Header("Player Reference")]
    public Transform player; // Reference to the player object

    void Start()
    {
        // Show WASD instructions at the start
        if (instructionText != null)
        {
            instructionText.text = "Use W, A, S, D to move.";
            instructionText.gameObject.SetActive(true);
            StartCoroutine(FadeOutText(instructionText, 5f)); // Fade out after 5 seconds
        }

        if (interactionText != null)
            interactionText.gameObject.SetActive(false); // Hide interaction prompts initially

        if (completionText != null)
            completionText.gameObject.SetActive(false); // Hide completion message initially
    }

    // Smoothly fades out text over time
    IEnumerator FadeOutText(TextMeshProUGUI text, float fadeDuration)
    {
        float elapsedTime = 0f;
        Color originalColor = text.color;

        while (elapsedTime < fadeDuration)
        {
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        text.gameObject.SetActive(false);
    }

    // Handle level completion UI
    public void ShowLevelComplete()
    {
        if (completionText != null)
        {
            completionText.text = "Level Completed!";
            completionText.gameObject.SetActive(true);
            StartCoroutine(FadeOutText(completionText, 5f)); // Fades out after 5 seconds
        }
    }
}
