using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    private int currentHealth;

    [Header("UI")]
    public Slider healthSlider; // Assign in Inspector

    [Header("Camera Shake")]
    public float shakeDuration = 0.2f;
    public float shakeMagnitude = 0.2f;

    [Header("Audio Settings")]
    public AudioSource hurtAudioSource; // Assign an AudioSource with a hurt clip
    [Range(0f, 1f)]
    public float hurtVolume = 1f;

    private Vector3 camOriginalPos;
    private Camera mainCam;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();

        mainCam = Camera.main;
        if (mainCam != null)
            camOriginalPos = mainCam.transform.localPosition;

        if (hurtAudioSource != null)
            hurtAudioSource.volume = hurtVolume;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Player took " + damage + " damage. Current HP: " + currentHealth);

        // Play hurt sound
        if (hurtAudioSource != null)
        {
            hurtAudioSource.volume = hurtVolume;
            hurtAudioSource.Play();
        }

        UpdateUI();
        StartCoroutine(ShakeCamera());

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
    }

    IEnumerator ShakeCamera()
    {
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
        Debug.Log("Player Died!");
        // Add death logic here
        gameObject.SetActive(false);
    }
}
