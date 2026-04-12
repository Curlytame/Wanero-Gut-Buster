using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject helpPanel;
    public GameObject almanacButton;

    [Header("Audio Sources")]
    public AudioSource backgroundMusic;
    public AudioSource sfxSource;

    [Header("Mute Button Objects")]
    public GameObject bgmMuteButton;
    public GameObject bgmUnmuteButton;
    public GameObject sfxMuteButton;
    public GameObject sfxUnmuteButton;

    // --- Play loads another scene ---
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    // --- Show Panels ---
    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        helpPanel.SetActive(false);
        almanacButton.SetActive(true);
    }

    public void ShowSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
        helpPanel.SetActive(false);
        almanacButton.SetActive(false);
    }

    public void ShowHelp()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        helpPanel.SetActive(true);
        almanacButton.SetActive(false);
    }

    // --- BGM Buttons ---
    public void MuteBGM()
    {
        backgroundMusic.volume = 0f;
        bgmMuteButton.SetActive(false);
        bgmUnmuteButton.SetActive(true);
        Debug.Log("BGM Muted");
    }

    public void UnmuteBGM()
    {
        backgroundMusic.volume = 1f;
        bgmMuteButton.SetActive(true);
        bgmUnmuteButton.SetActive(false);
        Debug.Log("BGM Unmuted");
    }

    // --- SFX Buttons ---
    public void MuteSFX()
    {
        sfxSource.volume = 0f;
        sfxMuteButton.SetActive(false);
        sfxUnmuteButton.SetActive(true);
        Debug.Log("SFX Muted");
    }

    public void UnmuteSFX()
    {
        sfxSource.volume = 1f;
        sfxMuteButton.SetActive(true);
        sfxUnmuteButton.SetActive(false);
        Debug.Log("SFX Unmuted");
    }

    // --- Exit ---
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}