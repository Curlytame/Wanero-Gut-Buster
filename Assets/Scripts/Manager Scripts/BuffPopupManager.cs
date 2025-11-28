using System.Collections;
using UnityEngine;

public class BuffIconManager : MonoBehaviour
{
    [Header("References")]
    public PlayerStats playerStats; // Assign in Inspector
    public Transform iconSpawnPosition; // Usually above player

    [Header("Buff Icon Prefabs")]
    public GameObject attackBuffIcon;
    public GameObject defenseBuffIcon;

    [Header("Animation Settings")]
    public float riseSpeed = 1.5f;
    public float fadeDuration = 1f;

    private int lastAttackBuff = 0;
    private int lastDefenseBuff = 0;

    void Start()
    {
        if (playerStats == null)
            playerStats = FindObjectOfType<PlayerStats>();

        if (playerStats != null)
        {
            lastAttackBuff = playerStats.attackBonus;
            lastDefenseBuff = playerStats.defence;
        }
    }

    void Update()
    {
        if (playerStats == null) return;

        // Check for attack buff increase
        if (playerStats.attackBonus > lastAttackBuff)
        {
            int diff = playerStats.attackBonus - lastAttackBuff;
            SpawnBuffIcon(attackBuffIcon);
        }

        // Check for defense buff increase
        if (playerStats.defence > lastDefenseBuff)
        {
            int diff = playerStats.defence - lastDefenseBuff;
            SpawnBuffIcon(defenseBuffIcon);
        }

        // Update last values
        lastAttackBuff = playerStats.attackBonus;
        lastDefenseBuff = playerStats.defence;
    }

    private void SpawnBuffIcon(GameObject iconPrefab)
    {
        if (iconPrefab == null || iconSpawnPosition == null) return;

        GameObject icon = Instantiate(iconPrefab, iconSpawnPosition.position, Quaternion.identity);
        StartCoroutine(AnimateIcon(icon));
    }

    private IEnumerator AnimateIcon(GameObject icon)
    {
        float timer = 0f;
        SpriteRenderer sr = icon.GetComponent<SpriteRenderer>();
        Color startColor = sr != null ? sr.color : Color.white;

        while (timer < fadeDuration)
        {
            // Rise
            icon.transform.position += Vector3.up * riseSpeed * Time.deltaTime;

            // Fade
            if (sr != null)
            {
                sr.color = new Color(startColor.r, startColor.g, startColor.b, Mathf.Lerp(1f, 0f, timer / fadeDuration));
            }

            timer += Time.deltaTime;
            yield return null;
        }

        Destroy(icon);
    }
}
