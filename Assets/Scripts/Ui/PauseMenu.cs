using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject pauseMenuPanel;
    public GameObject settingsPanel;

    [Header("Buttons")]
    public Button pauseButton;
    public Button resumeButton;
    public Button settingsButton;
    public Button menuButton;

    [Header("Settings Buttons")]
    public Button soundToggleButton;
    public Button settingsBackButton;

    private bool isPaused = false;
    private bool soundOn = true;

    void Start()
    {
        pauseMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);

        // Button listeners
        pauseButton.onClick.AddListener(TogglePause);
        resumeButton.onClick.AddListener(ResumeGame);
        settingsButton.onClick.AddListener(OpenSettings);
        menuButton.onClick.AddListener(ReturnToMenu);

        soundToggleButton.onClick.AddListener(ToggleSound);
        settingsBackButton.onClick.AddListener(CloseSettings);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsPanel.activeSelf)
                CloseSettings();
            else
                TogglePause();
        }
    }

    // -----------------------------
    // Pause / Resume
    // -----------------------------
    public void TogglePause()
    {
        if (settingsPanel.activeSelf)
            return;

        isPaused = !isPaused;
        ApplyPauseState();
    }

    public void ResumeGame()
    {
        isPaused = false;
        ApplyPauseState();
    }

    private void ApplyPauseState()
    {
        pauseMenuPanel.SetActive(isPaused);
        settingsPanel.SetActive(false);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    // -----------------------------
    // Settings
    // -----------------------------
    void OpenSettings()
    {
        pauseMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    void CloseSettings()
    {
        settingsPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
    }

    void ToggleSound()
    {
        soundOn = !soundOn;
        AudioListener.volume = soundOn ? 1f : 0f;
    }

    // -----------------------------
    // Menu
    // -----------------------------
    void ReturnToMenu()
    {
        Time.timeScale = 1f;

        // Stop background music before leaving scene
        if (SoundManager.Instance != null)
            SoundManager.Instance.StopBackgroundMusic();

        SceneManager.LoadScene("Menu");
    }
}
