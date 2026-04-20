using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] List<AudioSource> audioSources;
    [SerializeField] List<AudioClip> audioClips;



    public void PlaySound(int clipNumber)
    {
        foreach (AudioSource source in audioSources)
        {
            if (!source.isPlaying)
            {

                source.clip = audioClips[clipNumber];
                source.Play();

                return;
            }
        }

        


    }





}
