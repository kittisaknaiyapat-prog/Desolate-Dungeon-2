using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] List<AudioSource> Audiosources;
    [SerializeField] List<AudioClip> AudioClips;
    // Update is called once per frame
    public void playsound(int clipNumber)
    {
        Audiosources[0].clip= AudioClips[clipNumber];
        Audiosources[0].Play();

    }
}
