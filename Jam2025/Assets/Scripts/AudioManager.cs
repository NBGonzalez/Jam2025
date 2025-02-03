using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public enum SoundType
{
    Ambient,
    OpenDoor,
    CloseDoor,
    KnockDoor,
    Unlock,
    Keys,
    FootStep,
    Push,
    Nails,
    Button
}

[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class AudioManager : MonoBehaviour
{
    public float timer = 0;
    [SerializeField] private SoundList[] soundList;
    private static AudioManager instance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource ambientAudio;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void PlaySound(SoundType sound, float volume)
    {
        AudioClip[] clips = instance.soundList[(int)sound].Sounds;
        AudioClip randomClip = clips[Random.Range(0, clips.Length)];
        instance.audioSource.PlayOneShot(randomClip, volume);
    }

    public void Play(SoundType sound)
    {
        AudioClip[] clips = soundList[(int)sound].Sounds;
        AudioClip randomClip = clips[Random.Range(0, clips.Length)];
        audioSource.PlayOneShot(randomClip, 1);
    }

    public void ButtonSound()
    {
        AudioClip[] clips = soundList[(int)SoundType.Button].Sounds;
        AudioClip randomClip = clips[Random.Range(0, clips.Length)];
        audioSource.PlayOneShot(randomClip, 1);
    }

    private void Update()
    {
        //timer += Time.deltaTime;
        //if (timer >= 240)
        //{
        //    timer = 0;
        //    StartCoroutine(Fade(false, ambientAudio, 5, 0));
        //}
    }

    private IEnumerator Fade(bool fadeIn, AudioSource source, float duration, float targetVolume)
    {
        //if (!fadeIn)
        //{
        //    double lengthOfSource = (double)source.clip.samples / source.clip.frequency;
        //    yield return new WaitForSecondsRealtime((float)(lengthOfSource - duration));
        //    source.Stop();
        //}

        float time = 0f;
        float startVol = source.volume;

        while (time < duration)
        {
            time += Time.deltaTime;
            source.volume = Mathf.Lerp(startVol, targetVolume, time / duration);
            yield return null;
        }

        if (!fadeIn) source.Stop();

        ambientAudio.Play();
        StartCoroutine(Fade(true, source, 5, 0.3f));
        yield break;
    }


#if UNITY_EDITOR
    private void OnEnable()
    {
        string[] names = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundList, names.Length);

        for (int i = 0; i < soundList.Length; i++)
        {
            soundList[i].name = names[i];
        }
    }
#endif
}

[Serializable]
public struct SoundList
{
    public AudioClip[] Sounds { get => sounds; }
    [HideInInspector] public string name;
    [SerializeField] private AudioClip[] sounds;
}
