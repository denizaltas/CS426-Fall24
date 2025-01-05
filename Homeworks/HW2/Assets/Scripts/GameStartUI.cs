using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStartUI : MonoBehaviour
{
    [Header("Buttons")]
    public Button startButton; // Start Button
    public Button instructionsButton; // Instructions Button
    public Button closeButton; // Close Button for Instructions Panel

    [Header("Panels")]
    public GameObject MainMenuPanel;
    public GameObject instructionsPanel;

    void Start()
    {
        // Attach listeners to buttons
        startButton.onClick.AddListener(StartGame);
        instructionsButton.onClick.AddListener(ShowInstructions);
        closeButton.onClick.AddListener(HideInstructions);

        // Ensure InstructionsPanel is hidden initially
        instructionsPanel.SetActive(false);
    }

    void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    void HideInstructions()
    {
        instructionsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
}
