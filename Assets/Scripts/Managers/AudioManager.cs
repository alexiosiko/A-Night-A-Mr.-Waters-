using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource mainMusicSource;
    [SerializeField] AudioSource chaseMusicSource;
    [SerializeField] AudioSource soundEffectSource;
    public void PlaySoundEffect(string text)
    {
        switch (text)
        {
            case "pickup": soundEffectSource.Play(); break;
            default: print("No soundeffect of name " + text + " exists!"); return;
        }
    }
    public void PlayMusic(string music)
    {
        switch (music)
        {
            case "chaseMusic":
                mainMusicSource.Stop();
                break;
            case "mainMusic":
                mainMusicSource.Play();
                break;
        }
    }
    public void StopMusic(string music)
    {
        switch (music)
        {
            case "chaseMusic":
                StartCoroutine(FadeMusic(chaseMusicSource));
                break;
            case "mainMusic":
                StartCoroutine(FadeMusic(mainMusicSource));
                break;
        }
    }
    IEnumerator FadeMusic(AudioSource source)
    {
        float storeVolume = source.volume;
        DOTween.To( () => source.volume, x => source.volume = x, 0, 2);
        yield return new WaitForSeconds(2);
        source.Stop();
        source.volume = storeVolume;

    }
    public bool IsPlaying(string music)
    {
        switch (music)
        {
            case "chaseMusic": return chaseMusicSource.isPlaying;
            case "mainMusic": return mainMusicSource.isPlaying;
            default: print("No music of name " + music + " exists!"); return false;
        }
    }
    public static AudioManager instance;
    void Awake()
    {
        instance = this;
    }
}
