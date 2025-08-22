using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
   
    public static SoundManager Instance;

    public Sound[] bgmSound;

    public Sound[] sfxSound;

    public AudioSource bgmSource;

    public AudioSource sfxSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlayMusic(string Name)
    {
        Sound sound = Array.Find(bgmSound, x => x.name == Name);

        if(sound == null)
        {
            Debug.Log("���� �ش� BGM�� ã�� �� �����ϴ�");
        }
        else
        {
            bgmSource.clip = sound.clip;

            bgmSource.Play();
        }

    }


    public void PlaySFX(string Name)
    {
        Sound sound = Array.Find(sfxSound, x => x.name == Name);

        if (sound == null)
        {
            Debug.Log("�ش� ȿ������ ã�� �� �����ϴ�");
        }
        else
        {
            sfxSource.PlayOneShot(sound.clip);
        }
    }

    public void ToggleMusic()
    {
        bgmSource.mute = !bgmSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

}
