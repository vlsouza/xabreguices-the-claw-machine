using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] soudEffects;
    //public AudioSource backgroundMusic, levelEndMusic, bossMusic;
    public AudioSource menuMusic, levelMusic;

    private void Awake()
    {
        instance = this;
    }

    public void PlayMenuTheme(float startPoint)
    {
        if (!menuMusic.isPlaying)
        {
            menuMusic.time = startPoint;
            menuMusic.Play();
        }
    }

    public void PlayGameplayTheme(float startPoint)
    {
        if (!levelMusic.isPlaying)
        {
            levelMusic.time = startPoint;
            levelMusic.Play();
        }
    }

    public void PlaySFX(int soundToPlay)
    {
        // repetir o áudio quando chamado em sequência
        //soudEffects[soundToPlay].Stop();

        // tonalidade random
        //soudEffects[soundToPlay].pitch = Random.Range(.9f, 1.1f);

        if (!soudEffects[soundToPlay].isPlaying)
        {
            soudEffects[soundToPlay].Play();
        }
    }

    public void PlaySFXQuick(int soundToPlay)
    {
        soudEffects[soundToPlay].Stop();
        soudEffects[soundToPlay].Play();
    }

    public void PlaySFXOnce(int soundToPlay)
    {
        soudEffects[soundToPlay].PlayOneShot(soudEffects[soundToPlay].clip);
    }
}
