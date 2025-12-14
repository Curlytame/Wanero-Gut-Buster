using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PanelSlideUI : MonoBehaviour
{
    [Header("Panel & Buttons")]
    public RectTransform panel;
    public Button openButton;
    public Button closeButton;

    [Header("Animation Settings")]
    public float animationDuration = 0.3f;
    public Vector2 hiddenPosition = new Vector2(0, -800);
    public Vector2 shownPosition = Vector2.zero;

    private Coroutine currentRoutine;

    private void Start()
    {
        panel.anchoredPosition = hiddenPosition;
        panel.gameObject.SetActive(false);

        // Hook up button events
        if (openButton != null)
            openButton.onClick.AddListener(OpenPanel);

        if (closeButton != null)
            closeButton.onClick.AddListener(ClosePanel);
    }

    public void OpenPanel()
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        panel.gameObject.SetActive(true);
        currentRoutine = StartCoroutine(AnimatePanel(hiddenPosition, shownPosition));
    }

    public void ClosePanel()
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        currentRoutine = StartCoroutine(CloseRoutine());
    }

    private IEnumerator CloseRoutine()
    {
        yield return AnimatePanel(shownPosition, hiddenPosition);
        panel.gameObject.SetActive(false);
    }

    private IEnumerator AnimatePanel(Vector2 start, Vector2 end)
    {
        float elapsed = 0f;

        while (elapsed < animationDuration)
        {
            elapsed += Time.unscaledDeltaTime;
            float t = elapsed / animationDuration;
            panel.anchoredPosition = Vector2.Lerp(start, end, t);
            yield return null;
        }

        panel.anchoredPosition = end;
    }
}
