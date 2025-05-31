using UnityEngine;
public class SoundManager : MonoBehaviour
{
  public static SoundManager Instance { get; private set; }

    private AudioSource sfxSource; // do d�wi�k�w (klikni�cia w przycisk)
    private AudioSource musicSource; // do muzyki w tle

    [Header("D�wi�ki")]
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip gameStartSound;
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip chestSound;
    [SerializeField] private AudioClip portalSound;

    [Header("Domy�lna muzyka")]
    [SerializeField] private AudioClip menuMusic;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // 2 niezale�ne �r�d�a d�wi�ku
            sfxSource = gameObject.AddComponent<AudioSource>();
            musicSource = gameObject.AddComponent<AudioSource>();

            // Konfiguracja muzyki
            musicSource.loop = true;
            musicSource.playOnAwake = false;

            // Uruchom muzyk� menu, je�li przypisana
            if (menuMusic != null)
            {
                PlayBackgroundMusic(menuMusic);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayPortalSound()
    {
        if (portalSound != null)
        {
            sfxSource.PlayOneShot(portalSound);
        }
    }
    
    
    public void PlayChestSound()
    {
        if (chestSound != null)
        {
            sfxSource.PlayOneShot(chestSound);
        }
    }
    
    
    
    public void PlayHitSound()
    {
        if (hitSound != null)
        {
            sfxSource.PlayOneShot(hitSound);
        }
    }
    
    
    public void PlayPickupSound()
    {
        if (pickupSound != null)
        {
            sfxSource.PlayOneShot(pickupSound);
        }
    }
    public void PlayClickSound()
    {
        if (clickSound != null)
        {
            sfxSource.PlayOneShot(clickSound);
        }

    }
    public void PlayGameStartSound()
    {
        if (gameStartSound != null)
        {
            sfxSource.PlayOneShot(gameStartSound);
        }
    }

    public void PlayBackgroundMusic(AudioClip newMusic)
    {
        if (newMusic == null) return;
        if (musicSource.clip == newMusic) return; // nie zmieniaj, je�li to ta sama muzyka

        musicSource.Stop();
        musicSource.clip = newMusic;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}
