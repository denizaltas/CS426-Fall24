using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [Header("Buttons")]
    public Button retryButton;
    public Button mainMenuButton;

    void Start()
    {
        Time.timeScale = 1f;

        if (retryButton != null)
            retryButton.onClick.AddListener(RetryGame);
        
        if (mainMenuButton != null)
            mainMenuButton.onClick.AddListener(ReturnToMainMenu);
    }

    public void RetryGame()
    {
        Debug.Log("Retrying Game...");
        SceneManager.LoadScene("GameScene");
    }

    public void ReturnToMainMenu()
    {
        Debug.Log("Returning to Main Menu...");
        SceneManager.LoadScene("StartScene");
    }
}
