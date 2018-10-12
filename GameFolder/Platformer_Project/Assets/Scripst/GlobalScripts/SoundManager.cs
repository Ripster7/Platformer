using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    GameObject SliderX;                         // Slider

    public AudioClip[] sounds;                  // list of sounds
    public AudioClip[] music;                   // list of Music to be used
    public AudioClip[] UISounds;                // list of UISounds to be used
    public AudioClip[] CharSounds;              // list of Character Sounds to be used
    public AudioClip[] enemySounds;              // list of Character Sounds to be used


    private static SoundManager soundMan;       // global SoundManager instance
    private AudioSource sfxAudio;               // AudioSource component for playing sound fx.
    private AudioSource musicAudio;             // AudioSource component for playing music
    private AudioSource UIAudio;                // UI Sounds
    private AudioSource charAudio;             // Character Sounds
    private AudioSource enemyAudio;             // Enemy Sounds

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
        UIAudio = gameObject.AddComponent<AudioSource>();
        charAudio = gameObject.AddComponent<AudioSource>();
        musicAudio = gameObject.AddComponent<AudioSource>();
        enemyAudio = gameObject.AddComponent<AudioSource>();

        audioSourceStart = gameObject.AddComponent<AudioSource>();

        //change based on whats happening at start.
        sfxAudio.playOnAwake = false;
        musicAudio.playOnAwake = false;

        // loop music once finished
        musicAudio.loop = true;


        audioSource = gameObject.GetComponent<AudioSource>();
        audioSourceStart = gameObject.GetComponent<AudioSource>();
    }

    // GENERIC SOUND EFFECTS
    // -----------------------------------------------

    public static void PlaySfx(string sfxName)
    {
        if (soundMan == null)
        {
            Debug.LogWarning("Attempt to play a sound with no SoundManager in the scene");
            return;
        }

        soundMan.PlaySound(sfxName, soundMan.sounds, soundMan.sfxAudio);
    }

    // OVERLOADED FUNC
    public static void PlaySfx(AudioClip clip)
    {
        soundMan.PlaySound(clip, soundMan.sfxAudio);
    }

    // PLAYER SOUND EFFECTS
    // -----------------------------------------------

    public static void PlayCharSound(string sfxName)
    {
        if (soundMan == null)
        {
            Debug.LogWarning("Attempt to play a sound with no SoundManager in the scene");
            return;
        }

        soundMan.PlaySound(sfxName, soundMan.CharSounds, soundMan.charAudio);
    }

    // OVERLOADED FUNC
    public static void PlayCharSound(AudioClip clip)
    {
        soundMan.PlaySound(clip, soundMan.charAudio);
    }

    // UI SOUND EFFECTS
    // -----------------------------------------------

    public static void PlayUISound(string sfxName)
    {
        if (soundMan == null)
        {
            Debug.LogWarning("Attempt to play a sound with no SoundManager in the scene");
            return;
        }

        soundMan.PlaySound(sfxName, soundMan.UISounds, soundMan.UIAudio);
    }

    // OVERLOADED FUNC
    public static void PlayUISound(AudioClip clip)
    {
        soundMan.PlaySound(clip, soundMan.UIAudio);
    }

    // ENEMY SOUND EFFECTS
    // -----------------------------------------------

    public static void PlayEnemySound(string sfxName)
    {
        if (soundMan == null)
        {
            Debug.LogWarning("Attempt to play a sound with no SoundManager in the scene");
            return;
        }

        soundMan.PlaySound(sfxName, soundMan.enemySounds, soundMan.enemyAudio);
    }

    // OVERLOADED FUNC
    public static void PlayEnemySound(AudioClip clip)
    {
        soundMan.PlaySound(clip, soundMan.enemyAudio);
    }

    // MUSIC TRACKS
    // -----------------------------------------------


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

    // Pause the music. Takes in a "fadeTime" float, for time it takes to fade the music out.
    public static void PauseMusic(float fadeTime)
    {
        if (fadeTime > 0.0f)
            soundMan.StartCoroutine(soundMan.FadeMusicOut(fadeTime));
        else
            soundMan.musicAudio.Pause();
    }

    // Unpause music, reset volume.
    public static void UnpauseMusic()
    {
        soundMan.musicAudio.volume = 1.0f;
        soundMan.musicAudio.Play();
    }


    // Play Sound, the main sound func. Takes in each info to assign correct volume nob.
    private void PlaySound(string soundName, AudioClip[] pool, AudioSource audioOut)
    {
        foreach (AudioClip clip in pool)
        {
            if (clip.name == soundName)
            {
                PlaySound(clip, audioOut);
                return;
            }
            else
            {
                Debug.LogError(" TEST, Sound NOT found, check for a sound called --> " + soundName);
            }
        }

        Debug.Log(" Attempt to play SOUND --> " + soundName);
    }

    // OVERLOADED FUNC
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

    // Slider values changer.
    //---------------------------------------------------

    public void changeSoundLevels()
    {
        SliderX = GameObject.Find("VolumeSlider");
        Slider SliderV = SliderX.GetComponent<Slider>();


        sfxAudio.volume = SliderV.value;
        musicAudio.volume = SliderV.value;
        UIAudio.volume = SliderV.value;
        charAudio.volume = SliderV.value;
        musicAudio.volume = SliderV.value;
        enemyAudio.volume = SliderV.value;

        Debug.Log("Volume Levels = " + sfxAudio.volume);
    }
}
