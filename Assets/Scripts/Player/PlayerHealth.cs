using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [Header("References")]
    public PlayerStats stats; // Assign manually if needed

    [Header("UI")]
    public Slider healthSlider; // Assign in Inspector

    [Header("Camera Shake")]
    public float shakeDuration = 0.2f;
    public float shakeMagnitude = 0.2f;

    [Header("Audio Settings")]
    public AudioSource hurtAudioSource;
    [Range(0f, 1f)]
    public float hurtVolume = 1f;

    private Vector3 camOriginalPos;
    private Camera mainCam;

    void Start()
    {
        if (stats == null)
        {
            stats = GetComponent<PlayerStats>();
            if (stats == null)
                Debug.LogError("❌ PlayerStats reference missing on PlayerHealth!");
        }

        if (healthSlider == null)
            Debug.LogError("❌ HealthSlider not assigned in PlayerHealth!");

        mainCam = Camera.main;
        if (mainCam != null)
            camOriginalPos = mainCam.transform.localPosition;

        if (hurtAudioSource != null)
            hurtAudioSource.volume = hurtVolume;

        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        if (stats == null) return;

        int finalDamage = Mathf.Max(0, damage - stats.defence);
        stats.ModifyHealth(-finalDamage);

        Debug.Log($"⚡ Player took {finalDamage} damage → Current HP: {stats.currentHealth}");

        if (hurtAudioSource != null)
        {
            hurtAudioSource.volume = hurtVolume;
            hurtAudioSource.Play();
        }

        UpdateUI();
        StartCoroutine(ShakeCamera());

        if (stats.currentHealth <= 0)
            Die();
    }

    public void Heal(int amount)
    {
        if (stats == null) return;

        stats.ModifyHealth(amount);
        Debug.Log($"💚 Player healed {amount} → Current HP: {stats.currentHealth}");
        UpdateUI();
    }

    void UpdateUI()
    {
        if (healthSlider != null && stats != null)
        {
            healthSlider.maxValue = stats.maxHealth;
            healthSlider.value = stats.currentHealth;
            Debug.Log($"🔄 Updating UI → Slider: {healthSlider.value}/{healthSlider.maxValue}");
        }
    }

    IEnumerator ShakeCamera()
    {
        if (mainCam == null) yield break;

        float elapsed = 0f;
        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            mainCam.transform.localPosition = camOriginalPos + new Vector3(x, y, 0f);
            elapsed += Time.deltaTime;
            yield return null;
        }

        mainCam.transform.localPosition = camOriginalPos;
    }

    void Die()
    {
        Debug.Log("💀 Player Died!");
        gameObject.SetActive(false);
    }
}
