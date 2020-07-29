using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField] AudioSource music;
    [SerializeField] SessionInfo info;

    void Start()
    {
        music.volume = info.musicVolume;
        music.Play();
    }

    public void ChangeVolume(float newVolume)
    {
        music.volume = newVolume;
        info.musicVolume = music.volume;
    }
}
