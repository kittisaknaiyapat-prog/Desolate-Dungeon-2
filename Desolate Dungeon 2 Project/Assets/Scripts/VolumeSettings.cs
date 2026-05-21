using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider; 

    private void Start()
    {
    
        if (myMixer.GetFloat("Music", out float musicMixerValue))
        {
            musicSlider.value = Mathf.Pow(10, musicMixerValue / 20);
        }
        musicSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });

    
        if (myMixer.GetFloat("SFX", out float sfxMixerValue))
        {
            SFXSlider.value = Mathf.Pow(10, sfxMixerValue / 20);
        }
        SFXSlider.onValueChanged.AddListener(delegate { SetSFXVolume(); });
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;

        if (volume <= 0.0001f)
        {
            myMixer.SetFloat("Music", -80f); 
        }
        else
        {
            myMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        }
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;

        if (volume <= 0.0001f)
        {
            myMixer.SetFloat("SFX", -80f); 
        }
        else
        {
            myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        }
    }
}