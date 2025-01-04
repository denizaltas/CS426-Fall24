using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("UI Screens")]
    public GameObject startScreen; // Start Game UI
    public GameObject deathScreen; // Death Screen UI
    public GameObject gameCompleteScreen; // Game Complete UI

    [Header("UI Text Elements")]
    public TextMeshProUGUI instructionText; // WASD instructions

    [Header("Player Reference")]
    public Transform player;
    private Vector3 playerStartPosition; // Player restart point

    private bool gameStarted = false; // Track if the game has started

    void Start()
    {
        if (player != null)
        {
            playerStartPosition = player.position;
        }

        ShowStartScreen();
    }

    void Update()
    {
        // Allow starting the game with Spacebar
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar Pressed - Starting Game");
            StartGame();
        }
    }

    void ShowStartScreen()
    {
        if (startScreen != null)
            startScreen.SetActive(true);

        if (deathScreen != null)
            deathScreen.SetActive(false);

        if (gameCompleteScreen != null)
            gameCompleteScreen.SetActive(false);

        if (instructionText != null)
            instructionText.gameObject.SetActive(false);

        Time.timeScale = 0f; // Pause the game until start is clicked
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGame()
    {
        if (gameStarted) return; // Prevent multiple triggers

        Debug.Log("StartGame Method Called!");

        // Hide Start Screen
        if (startScreen != null)
        {
            startScreen.SetActive(false);
            Debug.Log("Start Screen Deactivated");
        }

        // Show WASD instructions
        if (instructionText != null)
        {
            instructionText.gameObject.SetActive(true);
            instructionText.text = "Use W, A, S, D to move.";
            StartCoroutine(FadeOutText(instructionText, 5f)); // Fades out after 5 seconds
        }

        Time.timeScale = 1f; // Resume the game
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        gameStarted = true; // Mark the game as started
        Debug.Log("Game Started Successfully!");
    }

    public void ShowLevelComplete()
    {
        if (gameCompleteScreen != null)
        {
            gameCompleteScreen.SetActive(true); // Show the Game Complete screen
            Debug.Log("Game Complete Screen Activated");
        }

        Time.timeScale = 0f; // Pause the game
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


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
}
