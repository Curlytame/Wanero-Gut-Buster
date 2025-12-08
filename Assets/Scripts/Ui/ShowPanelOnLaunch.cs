using UnityEngine;

public class ShowPanelOnLaunch : MonoBehaviour
{
    // This keeps track for the CURRENT GAME SESSION only
    private static bool hasShown = false;

    [Header("Panel (put your logo here)")]
    public GameObject panel;

    [Header("Optional Auto-Hide")]
    public float hideAfterSeconds = 0f; // 0 = don't auto hide

    void Start()
    {
        if (!hasShown)
        {
            panel.SetActive(true);
            hasShown = true;

            if (hideAfterSeconds > 0)
            {
                Invoke(nameof(HidePanel), hideAfterSeconds);
            }
        }
        else
        {
            panel.SetActive(false);
        }
    }

    public void HidePanel()
    {
        panel.SetActive(false);
    }
}
