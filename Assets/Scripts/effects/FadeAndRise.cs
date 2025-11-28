using UnityEngine;

public class FadeAndRise : MonoBehaviour
{
    [Header("Movement & Fade")]
    public float riseSpeed = 1f;          // How fast the object moves up
    public float fadeDuration = 1f;       // How long it takes to fade
    private SpriteRenderer sr;
    private Color startColor;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr != null)
            startColor = sr.color;
        else
            startColor = Color.white;

        // Start the fade coroutine
        StartCoroutine(FadeAndRiseCoroutine());
    }

    private System.Collections.IEnumerator FadeAndRiseCoroutine()
    {
        float timer = 0f;

        while (timer < fadeDuration)
        {
            // Move upward
            transform.position += Vector3.up * riseSpeed * Time.deltaTime;

            // Fade alpha
            if (sr != null)
            {
                float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
                sr.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            }

            timer += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
