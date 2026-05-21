using UnityEngine;
using UnityEngine.SceneManagement; 

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

    public static AudioController Instance { get; private set; }

    private void Awake()
    {
   
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
 
        if (scene.name == "StartScene" || scene.name == "Settings 2 new")
        {
            PlayMusic(menumusic);
        }
        else
        {

            PlayMusic(background);
        }
    }

   
    public void PlayMusic(AudioClip clip)
    {

        if (musicSource.clip == clip) return;

        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}