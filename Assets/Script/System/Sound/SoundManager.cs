using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private IAudioPlayer[] audios;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        audios = GetComponents<IAudioPlayer>();
        if (audios == null || audios.Length == 0)
            Debug.LogWarning("No IAudioPlayer components found on SoundManager!");

        PlaySystemAudio((int)ESystemAudioClip.Theme, true);
    }

    public void PlaySystemAudio(int clipIndex, bool isLoop)
    {
        audios[0].SetLoop(isLoop);
        audios[0].Play(clipIndex);
    }
    public void PlaySystemAudioOneShot(int clipIndex)
    {
        audios[0].PlayOneShot(clipIndex);
    }
    public void StopSystemAudio() => audios[0].Stop();
    public void SetSystemAudioVolume(float volume) => audios[0].SetVolume(volume);
    public AudioSource GetSystemAudio() => audios[0].GetAudio();

    public void PlayUIAudio(int clipIndex, bool isLoop)
    {
        audios[1].PlayOneShot(clipIndex);
    }
    public void SetUIAudioVolume(float volume) => audios[1].SetVolume(volume);
    public AudioSource GetUIAudio() => audios[1].GetAudio();

    public void PlaySFXAudioOneShot(int clipIndex)
    {
        audios[2].PlayOneShot(clipIndex);
    }
    public void PlaySFX(int clipIindex)
    {
        audios[2].Play(clipIindex);
    }
    public void SetSFXVolume(float volume) => audios[2].SetVolume(volume);
    public AudioSource GetSFXAudio() => audios[2].GetAudio();
}
