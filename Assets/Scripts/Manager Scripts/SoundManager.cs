using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Sound Effects")]
    public AudioClip playerAttackSound;
    public AudioClip enemyAttackSound;
    public AudioClip fireEffectSound;

    [Header("Card / Fusion Sounds")]
    public AudioClip cardDrawSound;          // NEW
    public AudioClip fusionSuccessSound;     // NEW
    public AudioClip invalidFusionSound;     // NEW

    [Header("Settings")]
    public float volume = 1f;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.volume = volume;
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip == null) return;
        audioSource.PlayOneShot(clip, volume);
    }
}
