using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject helpPanel;

    private bool isMuted = false;

    // --- Play loads another scene ---
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); // Replace with your game scene name
    }

    // --- Show Panels ---
    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        helpPanel.SetActive(false);
    }

    public void ShowSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
        helpPanel.SetActive(false);
    }

    public void ShowHelp()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        helpPanel.SetActive(true);
    }

    // --- Audio Controls ---
    public void MuteAudio()
    {
        AudioListener.volume = 0f;
        isMuted = true;
        Debug.Log("Audio Muted");
    }

    public void UnmuteAudio()
    {
        AudioListener.volume = 1f;
        isMuted = false;
        Debug.Log("Audio Unmuted");
    }

    // --- Exit ---
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed"); // Works only in build
    }
}
