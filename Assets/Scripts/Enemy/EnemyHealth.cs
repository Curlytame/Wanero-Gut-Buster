using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

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

    private Vector3 originalPosition;
    private SpriteRenderer[] childRenderers;
    private GameObject[] normalSpriteObjects;

    void Start()
    {
        if (stats == null)
            stats = GetComponent<EnemyStats>();

        // Ensure health initialized
        if (stats.currentHealth > stats.maxHealth)
            stats.currentHealth = stats.maxHealth;

        UpdateUI();

        childRenderers = GetComponentsInChildren<SpriteRenderer>();

        normalSpriteObjects = new GameObject[transform.childCount];
        int i = 0;
        foreach (Transform child in transform)
        {
            if (child.gameObject != hurtSpriteObject)
            {
                normalSpriteObjects[i++] = child.gameObject;
            }
        }

        originalPosition = transform.localPosition;

        if (hurtSpriteObject != null)
            hurtSpriteObject.SetActive(false);

        if (hurtAudioSource != null)
            hurtAudioSource.volume = hurtVolume;
    }

    public void TakeDamage(int damage)
    {
        if (stats == null) return;

        int finalDamage = Mathf.Max(0, damage - stats.defense);
        stats.ModifyHealth(-finalDamage);

        Debug.Log($"Enemy took {finalDamage} damage (raw {damage}, defense {stats.defense}). Current HP: {stats.currentHealth}");

        if (hurtAudioSource != null)
        {
            hurtAudioSource.volume = hurtVolume;
            hurtAudioSource.Play();
        }

        UpdateUI();
        StartCoroutine(FlashAndShake());

        if (stats.currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (stats == null) return;

        stats.ModifyHealth(amount);
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
        {
            healthText.text = $"{stats.currentHealth} / {stats.maxHealth}";
        }
    }

    private IEnumerator FlashAndShake()
    {
        if (hurtSpriteObject != null)
        {
            foreach (var obj in normalSpriteObjects)
            {
                if (obj != null)
                    obj.SetActive(false);
            }

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
            {
                if (obj != null)
                    obj.SetActive(true);
            }
        }

        foreach (var renderer in childRenderers)
        {
            renderer.color = Color.white;
        }
    }

    private void Die()
    {
        Debug.Log("Enemy Died!");
        Destroy(gameObject);
    }
}
