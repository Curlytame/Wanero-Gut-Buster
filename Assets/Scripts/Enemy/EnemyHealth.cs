using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 50;
    private int currentHealth;

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
    public AudioSource hurtAudioSource; // Assign AudioSource with a hurt clip
    [Range(0f, 1f)]
    public float hurtVolume = 1f; // Adjustable in the Inspector

    private Vector3 originalPosition;
    private SpriteRenderer[] childRenderers;
    private GameObject[] normalSpriteObjects;

    void Start()
    {
        currentHealth = maxHealth;
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
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Enemy took " + damage + " damage. Current HP: " + currentHealth);

        // Play hurt sound
        if (hurtAudioSource != null)
        {
            hurtAudioSource.volume = hurtVolume; // Ensure it uses current volume
            hurtAudioSource.Play();
        }

        UpdateUI();
        StartCoroutine(FlashAndShake());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateUI()
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }

        if (healthText != null)
        {
            healthText.text = currentHealth + " / " + maxHealth;
        }
    }

    IEnumerator FlashAndShake()
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

    void Die()
    {
        Debug.Log("Enemy Died!");
        Destroy(gameObject);
    }
}
