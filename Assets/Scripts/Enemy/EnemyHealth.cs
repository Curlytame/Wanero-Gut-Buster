using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement; // Needed for scene loading

public class EnemyHealth : MonoBehaviour
{
    [Header("References")]
    public EnemyStats stats; // Link to EnemyStats

    [Header("UI References")]
    public Slider healthSlider;
    public TextMeshProUGUI healthText;

    [Header("Visual Feedback")]
    public float flashDuration = 0.1f;
    public float shakeMagnitude = 0.1f;
    public float shakeDuration = 0.2f;

    [Header("Sprite References")]
    public GameObject hurtSpriteObject;

    [Header("Audio Settings")]
    public AudioSource hurtAudioSource;
    [Range(0f, 1f)]
    public float hurtVolume = 1f;

    [Header("Death Fade Settings")]
    public float deathFadeDuration = 1f;
    public Vector3 deathMoveOffset = new Vector3(0, 2f, 0);

    [Header("Next Scene")]
    public string nextSceneName = ""; // Type scene name in inspector

    private Vector3 originalPosition;
    private SpriteRenderer[] childRenderers;
    private GameObject[] normalSpriteObjects;

    private bool isDead = false;

    void Start()
    {
        if (stats == null)
            stats = GetComponent<EnemyStats>();

        // Clamp health
        stats.currentHealth = Mathf.Clamp(stats.currentHealth, 0, stats.maxHealth);

        UpdateUI();

        childRenderers = GetComponentsInChildren<SpriteRenderer>();

        normalSpriteObjects = new GameObject[transform.childCount];
        int i = 0;
        foreach (Transform child in transform)
        {
            if (child.gameObject != hurtSpriteObject)
                normalSpriteObjects[i++] = child.gameObject;
        }

        originalPosition = transform.localPosition;

        if (hurtSpriteObject != null)
            hurtSpriteObject.SetActive(false);

        if (hurtAudioSource != null)
            hurtAudioSource.volume = hurtVolume;
    }

    public void TakeDamage(int damage)
    {
        if (stats == null || isDead) return;

        int finalDamage = Mathf.Max(0, damage - stats.defense);
        stats.ModifyHealth(-finalDamage);

        Debug.Log($"Enemy took {finalDamage} damage (raw {damage}, defense {stats.defense}). Current HP: {stats.currentHealth}");

        if (hurtAudioSource != null)
            hurtAudioSource.Play();

        UpdateUI();
        StartCoroutine(FlashAndShake());

        if (stats.currentHealth <= 0 && !isDead)
        {
            StartCoroutine(Die());
        }
    }

    public void Heal(int amount)
    {
        if (stats == null || isDead) return;

        stats.ModifyHealth(amount);
        stats.currentHealth = Mathf.Clamp(stats.currentHealth, 0, stats.maxHealth); // Clamp to max
        Debug.Log($"Enemy healed by {amount}. Current HP: {stats.currentHealth}");

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (stats == null) return;

        if (healthSlider != null)
        {
            healthSlider.maxValue = stats.maxHealth;
            healthSlider.value = stats.currentHealth;
        }

        if (healthText != null)
            healthText.text = $"{stats.currentHealth} / {stats.maxHealth}";
    }

    private IEnumerator FlashAndShake()
    {
        if (hurtSpriteObject != null)
        {
            foreach (var obj in normalSpriteObjects)
                if (obj != null) obj.SetActive(false);

            hurtSpriteObject.SetActive(true);
        }

        float elapsed = 0f;
        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-shakeMagnitude, shakeMagnitude);
            float y = Random.Range(-shakeMagnitude, shakeMagnitude);
            transform.localPosition = originalPosition + new Vector3(x, y, 0f);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;

        if (hurtSpriteObject != null)
        {
            hurtSpriteObject.SetActive(false);
            foreach (var obj in normalSpriteObjects)
                if (obj != null) obj.SetActive(true);
        }

        foreach (var renderer in childRenderers)
            renderer.color = Color.white;
    }

    private IEnumerator Die()
    {
        isDead = true;
        Debug.Log("Enemy Died!");

        // Disable colliders and other components
        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        // Fade and move upwards
        float timer = 0f;
        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
        Vector3 startPos = transform.position;

        while (timer < deathFadeDuration)
        {
            float t = timer / deathFadeDuration;

            foreach (var r in renderers)
            {
                if (r != null)
                {
                    Color c = r.color;
                    r.color = new Color(c.r, c.g, c.b, 1f - t);
                }
            }

            transform.position = Vector3.Lerp(startPos, startPos + deathMoveOffset, t);

            timer += Time.deltaTime;
            yield return null;
        }

        // Load next scene if set
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }

        Destroy(gameObject);
    }
}
