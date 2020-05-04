//Basic Music Manager - Third Games - 19-6-2019 - Timon van Waardhuizen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MuiscManager : MonoBehaviour
{
    #region Singleton
    private static MuiscManager _instance;
    public static MuiscManager Instance
    {
        get
        {
            if (_instance == null)
            {
                //uit nog niet nodig
                //GameObject go = new GameObject("MuiscManager");
                //go.AddComponent<MuiscManager>();
            }

            return _instance;
        }
    }
    #endregion

    [Header("Mixers")]
    public AudioMixer MasterMixer;

    [Header("Audio sources")]
    public AudioSource Music;
    public AudioSource Effects;
    public AudioSource EffectsLoop;
    public AudioSource CarSound;

    [Header("Audio clips")]
    #region Music
    public AudioClip MenuMusic;
    #endregion

    #region Effects
    public AudioClip SfxExplosion;
    public AudioClip SfxNextRound;
    public AudioClip SfxHitObject;
    public AudioClip SfxShoot;
    public AudioClip SfxAbility;
    #endregion

    #region Effects Loop
    public AudioClip Car;
    public AudioClip Shield;
    public AudioClip Beep;
    #endregion

    [Header("Music options")]
    public float MusicVolume;
    public float EffectVolume;
    public bool PlayOnce;

    private void Awake()
    {
        //start values
        _instance = this;
        MusicVolume = 1f;
        EffectVolume = 1f;
        PlayOnce = false;
        DontDestroyOnLoad(this.gameObject);
    }

    #region General Functions

    //turn off all sounds
    public void StopAll()
    {
        Music.Stop();
        Effects.Stop();
        EffectsLoop.Stop();
        CarSound.Stop();
    }

    //pause the music
    public void PauseMusic()
    {
        Music.Pause();
        Effects.Pause();
        EffectsLoop.Pause();
        CarSound.Pause();
    }

    //Unpause all the music
    public void UnpauseMusic()
    {
        Music.UnPause();
        Effects.UnPause();
        EffectsLoop.UnPause();
        CarSound.UnPause();
    }
    #endregion

    #region Play One Shot effects
    public void PlayShotExplosion()
    {
        Effects.PlayOneShot(SfxExplosion, 1f);
    }

    public void PlayShotNextRound()
    {
        Effects.PlayOneShot(SfxNextRound, 1f);
    }

    public void PlayShotAbilityPickUp()
    {
        Effects.PlayOneShot(SfxAbility, 1f);
    }

    public void PlayShotFireBullet()
    {
        Effects.PlayOneShot(SfxShoot, 0.1f);
    }

    public void PlayShotHitObject()
    {
        Effects.PlayOneShot(SfxHitObject, 1f);
    }
    #endregion

    #region Play Normal sounds
    public void PlayCarSound()
    {
        CarSound.Play();
    }

    public void PlayShieldSound()
    {
        if(PlayOnce == false)
        {
            EffectsLoop.clip = Shield;
            EffectsLoop.Play();
            PlayOnce = true;
        }
    }

    public void PlayBeepSound()
    {
        if (PlayOnce == false)
        {
            EffectsLoop.clip = Beep;
            EffectsLoop.Play();
            PlayOnce = true;
        }
    }
    #endregion

    #region Stop sounds
    public void StopCarSound()
    {
        CarSound.Stop();
    }

    public void StopEffectsLoopSound()
    {
        EffectsLoop.Stop();
        PlayOnce = false;
    }
    #endregion

    #region Music Set
    public void SetMusicVolume(float volume)
    {
        //mixer music volume veranderen
    }

    public void SetEffectsVolume(float volume)
    {
        //mixer effecten volume veranderen
    }

    public void SetCarPitch(float pitch)
    {
        CarSound.pitch = pitch;
    }

    public void PlayBackgroundSound(string name)
    {
        switch(name)
        {
            case "menu":
                Music.clip = MenuMusic;
                break;
            case "game":
                break;
        }

        Music.Play();
    }
    #endregion
}
