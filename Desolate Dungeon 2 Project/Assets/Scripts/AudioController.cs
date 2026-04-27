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


}
