using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCompleteUI : MonoBehaviour
{

    public Button mainMenuButton;
    public Button quitButton;

    void Start()
    {
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
        quitButton.onClick.AddListener(QuitGame);
    }
    // Function for Main Menu Button
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    // Function for Quit Button
    public void QuitGame()
    {
        Application.Quit();
    }
}

