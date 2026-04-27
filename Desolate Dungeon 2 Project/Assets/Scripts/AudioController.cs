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


    private void Start()
    {
        musicSource.clip = menumusic;
        musicSource.Play();
    }



    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
