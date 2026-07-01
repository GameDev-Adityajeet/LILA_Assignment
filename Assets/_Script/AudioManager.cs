using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Clips")]
    public AudioClip pickupSound;
    public AudioClip deliverySound;
    public AudioClip upgradeSound;
    public AudioClip gameOverSound;
    public AudioClip backgroundMusic;

    [Header("Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlayPickup() => sfxSource.PlayOneShot(pickupSound);
    public void PlayDelivery() => sfxSource.PlayOneShot(deliverySound);
    public void PlayUpgrade() => sfxSource.PlayOneShot(upgradeSound);
    public void PlayGameOver() => sfxSource.PlayOneShot(gameOverSound);
}