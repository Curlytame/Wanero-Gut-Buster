using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource bgSource;
    public AudioSource sfxSource;

    // ---------------- OLD REQUIRED CLIPS (DO NOT REMOVE) ----------------
    [Header("Legacy Clips (Used by Existing Scripts)")]
    public AudioClip cardDrawSound;
    public AudioClip invalidFusionSound;
    public AudioClip fusionSuccessSound;

    // ---------------- NEW CLIPS ----------------
    [Header("Combat & UI Clips")]
    public AudioClip playerAttackSound;
    public AudioClip enemyAttackSound;
    public AudioClip clickSound;
    public AudioClip backgroundMusic;

    // ---------------- VOLUMES ----------------
    [Header("Volumes")]
    [Range(0f, 1f)] public float bgVolume = 0.5f;
    [Range(0f, 1f)] public float sfxVolume = 1f;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        PlayBackgroundMusic();
    }

    // ---------------- LEGACY API (DO NOT BREAK) ----------------
    public void PlaySound(AudioClip clip)
    {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip, sfxVolume);
    }

    // ---------------- NEW API ----------------
    public void PlayPlayerAttack()
    {
        PlaySound(playerAttackSound);
    }

    public void PlayEnemyAttack()
    {
        PlaySound(enemyAttackSound);
    }

    public void PlayClick()
    {
        PlaySound(clickSound);
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusic == null) return;

        bgSource.clip = backgroundMusic;
        bgSource.loop = true;
        bgSource.volume = bgVolume;
        bgSource.Play();
    }
}
