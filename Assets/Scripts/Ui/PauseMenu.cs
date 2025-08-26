using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel; // Assign the "Menu" Panel here
    public Button pauseButton;
    public Button resumeButton;
    public Button settingsButton; // Currently disabled
    public Button menuButton;

    private bool isPaused = false;

    void Start()
    {
        pauseMenuPanel.SetActive(false); // Hide menu at start

        pauseButton.onClick.AddListener(TogglePause);
        resumeButton.onClick.AddListener(ResumeGame);
        menuButton.onClick.AddListener(ReturnToMenu);

        settingsButton.interactable = false; // Disable settings button for now
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenuPanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }

    void ResumeGame()
    {
        TogglePause();
    }

    void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu"); // Replace with your actual main menu scene name
    }
}
