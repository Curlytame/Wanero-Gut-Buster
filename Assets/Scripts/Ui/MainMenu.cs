using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Buttons")]
    public Button playButton;
    public Button backButton;
    public Button exitButton;

    [Header("Scene Names")]
    public string playSceneName = "GameScene";
    public string backSceneName = "Menu";

    void Start()
    {
        if (playButton != null)
            playButton.onClick.AddListener(() => LoadScene(playSceneName));

        if (backButton != null)
            backButton.onClick.AddListener(() => LoadScene(backSceneName));

        if (exitButton != null)
            exitButton.onClick.AddListener(ExitGame);
    }

    void LoadScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
            SceneManager.LoadScene(sceneName);
        else
            Debug.LogWarning("Scene name is empty!");
    }

    void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game (in editor this won't quit)");
    }
}
