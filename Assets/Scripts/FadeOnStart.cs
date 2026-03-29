using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOnStart : MonoBehaviour
{
    public float showDuration = 2f;
    public float fadeDuration = 1f;

    private Image uiImage;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        uiImage = GetComponent<Image>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        SetAlpha(1f); // fully visible
        StartCoroutine(FadeRoutine());
    }

    IEnumerator FadeRoutine()
    {
        yield return new WaitForSeconds(showDuration);

        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, time / fadeDuration);
            SetAlpha(alpha);
            yield return null;
        }

        SetAlpha(0f);
        gameObject.SetActive(false); // optional
    }

    void SetAlpha(float alpha)
    {
        if (uiImage != null)
        {
            Color c = uiImage.color;
            c.a = alpha;
            uiImage.color = c;
        }

        if (spriteRenderer != null)
        {
            Color c = spriteRenderer.color;
            c.a = alpha;
            spriteRenderer.color = c;
        }
    }
}