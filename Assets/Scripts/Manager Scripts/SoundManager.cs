using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource bgSource;
    public AudioSource sfxSource;

    [Header("Legacy Clips (Used by Existing Scripts)")]
    public AudioClip cardDrawSound;
    public AudioClip invalidFusionSound;
    public AudioClip fusionSuccessSound;

    [Header("Combat & UI Clips")]
    public AudioClip playerAttackSound;
    public AudioClip enemyAttackSound;
    public AudioClip clickSound;
    public AudioClip backgroundMusic;

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

    private void Update()
    {
        // Play click sound globally on left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            PlayClick();
        }
    }

    // ---------------- LEGACY API ----------------
    public void PlaySound(AudioClip clip)
    {
        if (clip == null || sfxSource == null) return;
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
        if (bgSource == null || backgroundMusic == null) return;

        if (!bgSource.isPlaying)
        {
            bgSource.clip = backgroundMusic;
            bgSource.loop = true;
            bgSource.volume = bgVolume;
            bgSource.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        if (bgSource != null && bgSource.isPlaying)
            bgSource.Stop();
    }
}
