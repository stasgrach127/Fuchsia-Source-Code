using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip[] sceneMusic;
    [SerializeField] AudioSource sceneSource;

    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip clockSound;
    [SerializeField] AudioClip coinSound;
    [SerializeField] AudioClip gameOverSound;
    [SerializeField] AudioClip portalSound;
    [SerializeField] AudioClip dangerSound;

    [SerializeField] AudioSource attackAudioSource;
    [SerializeField] AudioClip[] swordSounds;

    private void Start()
    {
        sceneSource.clip = sceneMusic[Random.Range(0, sceneMusic.Length)];
        sceneSource.Play();
    }

    public void PlaySound(string soundName)
    {
        switch (soundName)
        {
            case "clock":
                soundSource.Stop();
                soundSource.volume = 0.8f;
                soundSource.clip = clockSound;
                soundSource.Play();
                break;
            case "coin":
                soundSource.Stop();
                soundSource.volume = 0.3f;
                soundSource.clip = coinSound;
                soundSource.Play();
                break;
            case "gameover":
                soundSource.Stop();
                soundSource.volume = 0.5f;
                soundSource.clip = gameOverSound;
                soundSource.Play();
                break;
            case "portal":
                soundSource.Stop();
                soundSource.volume = 0.9f;
                soundSource.clip = portalSound;
                soundSource.Play();
                break;
            case "danger":
                soundSource.Stop();
                soundSource.volume = 0.4f;
                soundSource.clip = dangerSound;
                soundSource.Play();
                break;
        }
    }

    public void PlaySoundDirect(AudioClip soundClip)
    {
        soundSource.Stop();
        soundSource.volume = 0.5f;
        soundSource.clip = soundClip;
        soundSource.Play();
    }

    public void PlaySwordSound()
    {
        int sound = Random.Range(0, swordSounds.Length);
        attackAudioSource.Stop();
        attackAudioSource.volume = 0.5f;
        attackAudioSource.clip = swordSounds[sound];
        attackAudioSource.Play();
    }
}
