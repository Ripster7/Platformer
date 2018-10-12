using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] sounds;                  // list of sounds
    public AudioClip[] music;                   // list of Music to be used

    private static SoundManager soundMan;       // global SoundManager instance
    private AudioSource sfxAudio;               // AudioSource component for playing sound fx.
    private AudioSource musicAudio;             // AudioSource component for playing music

    private AudioSource audioSource;
    private AudioSource audioSourceStart;


    void Awake()
    {
        if (soundMan != null)
        {
            Debug.LogError("More than one SoundManager found in the scene");
            return;
        }


        soundMan = this;
        sfxAudio = gameObject.AddComponent<AudioSource>();
        musicAudio = gameObject.AddComponent<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSourceStart = gameObject.AddComponent<AudioSource>();

        sfxAudio.playOnAwake = false;
        musicAudio.playOnAwake = false;
        musicAudio.loop = true;


        audioSource = gameObject.GetComponent<AudioSource>();
        audioSourceStart = gameObject.GetComponent<AudioSource>();
    }

    public static void PlaySfx(string sfxName)
    {
        if (soundMan == null)
        {
            Debug.LogWarning("Attempt to play a sound with no SoundManager in the scene");
            return;
        }

        soundMan.PlaySound(sfxName, soundMan.sounds, soundMan.sfxAudio);
    }

    public static void PlaySfx(AudioClip clip)
    {
        soundMan.PlaySound(clip, soundMan.sfxAudio);
    }



    public static void PlayMusic(string trackName)
    {
        if (soundMan == null)
        {
            Debug.LogWarning("Attempt to play a sound with no SoundManager in the scene");
            return;
        }

        soundMan.musicAudio.time = 0.0f;
        soundMan.musicAudio.volume = 1.0f;

        soundMan.PlaySound(trackName, soundMan.music, soundMan.musicAudio);
    }


    public static void PauseMusic(float fadeTime)
    {
        if (fadeTime > 0.0f)
            soundMan.StartCoroutine(soundMan.FadeMusicOut(fadeTime));
        else
            soundMan.musicAudio.Pause();
    }


    public static void UnpauseMusic()
    {
        soundMan.musicAudio.volume = 1.0f;
        soundMan.musicAudio.Play();
    }



    private void PlaySound(string soundName, AudioClip[] pool, AudioSource audioOut)
    {
        foreach (AudioClip clip in pool)
        {
            if (clip.name == soundName)
            {
                PlaySound(clip, audioOut);
                return;
            }
        }

        Debug.LogWarning(" TEST --> " + soundName);
    }


    private void PlaySound(AudioClip clip, AudioSource audioOut)
    {
        audioOut.clip = clip;
        audioOut.Play();
    }




    IEnumerator FadeMusicOut(float time)
    {
        float startVol = musicAudio.volume;
        float startTime = Time.realtimeSinceStartup;

        while (true)
        {
            float t = (Time.realtimeSinceStartup - startTime) / time;
            if (t < 1.0f)
            {
                musicAudio.volume = (1.0f - t) * startVol;
                yield return 0;
            }
            else
            {
                break;
            }
        }

        musicAudio.Pause();
    }
}
