using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPanelController : MonoBehaviour
{
    [Header("UI")]
    public GameObject videoPanel;
    public Button openButton;
    public Button closeButton;

    [Header("Video")]
    public VideoPlayer videoPlayer;

    void Start()
    {
        if (videoPanel != null)
            videoPanel.SetActive(false);

        if (openButton != null)
            openButton.onClick.AddListener(OpenVideoPanel);

        if (closeButton != null)
            closeButton.onClick.AddListener(CloseVideoPanel);
    }

    public void OpenVideoPanel()
    {
        if (videoPanel != null)
            videoPanel.SetActive(true);

        if (videoPlayer != null)
        {
            videoPlayer.Stop();
            videoPlayer.time = 0;
            videoPlayer.Play();
        }
    }

    public void CloseVideoPanel()
    {
        if (videoPanel != null)
            videoPanel.SetActive(false);

        if (videoPlayer != null)
        {
            videoPlayer.Stop();
            videoPlayer.time = 0;
        }
    }
}
