using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public Button retryButton;
    public Button mainMenuButton;

    void Start()
    {
        retryButton.onClick.AddListener(RetryGame);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
    }

    void RetryGame()
    {
        SceneManager.LoadScene("GameScene"); 
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene("StartScene"); 
    }
}
