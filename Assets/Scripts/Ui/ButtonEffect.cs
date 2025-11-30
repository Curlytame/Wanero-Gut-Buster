using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement; // For scene loading

public class ButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Button State")]
    public bool Unlocked = false;

    [Header("Scene Settings")]
    public string sceneToLoad; // Scene name to load on click

    [Header("Scale & Shake")]
    public float hoverScale = 1.2f;
    public float scaleSpeed = 5f;
    public float shakeDuration = 0.3f;
    public float shakeMagnitude = 10f;

    [Header("Audio Settings")]
    public AudioSource audioSource; // Shared AudioSource (assign in Inspector)

    public AudioClip lockedClip;
    [Range(0f, 1f)] public float lockedVolume = 1f;

    public AudioClip unlockedClip;
    [Range(0f, 1f)] public float unlockedVolume = 1f;

    private Vector3 originalScale;
    private RectTransform rectTransform;
    private bool isHovered = false;
    private Coroutine currentShake;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
    }

    void Update()
    {
        // Smooth hover scaling
        Vector3 targetScale = isHovered ? originalScale * hoverScale : originalScale;
        rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, targetScale, Time.deltaTime * scaleSpeed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!Unlocked)
        {
            // Play locked sound
            if (audioSource != null && lockedClip != null)
            {
                audioSource.PlayOneShot(lockedClip, lockedVolume);
            }

            // Shake button
            if (currentShake != null)
                StopCoroutine(currentShake);
            currentShake = StartCoroutine(ShakeButton());
        }
        else
        {
            // Play unlocked sound
            if (audioSource != null && unlockedClip != null)
            {
                audioSource.PlayOneShot(unlockedClip, unlockedVolume);
            }

            Debug.Log("Button clicked: Unlocked");

            // Load assigned scene if specified
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.LogWarning("No scene assigned in inspector for this button!");
            }
        }
    }

    private IEnumerator ShakeButton()
    {
        Vector3 originalPos = rectTransform.anchoredPosition;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float offsetX = Random.Range(-1f, 1f) * shakeMagnitude;
            float offsetY = Random.Range(-1f, 1f) * shakeMagnitude;
            rectTransform.anchoredPosition = originalPos + new Vector3(offsetX, offsetY, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = originalPos;
        currentShake = null;
    }
}
