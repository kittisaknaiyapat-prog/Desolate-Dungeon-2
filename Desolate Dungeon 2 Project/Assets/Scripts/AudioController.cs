using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip menumusic;
    public AudioClip background;
    public AudioClip death;
    public AudioClip walking;
    public AudioClip buttonclick;
    public AudioClip returnbuttonclick;
    private static AudioController instance;
    public static AudioController GetInstance()
    {
        return instance;
    }
    private void Start()
    {
        musicSource.clip = menumusic;
        musicSource.Play();
        if (instance)
        {
            Destroy(gameObject);

            return;
        }

        DontDestroyOnLoad(gameObject);

        instance = this;

    }



    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
