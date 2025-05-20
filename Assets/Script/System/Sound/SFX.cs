using UnityEngine;

public class SFX : MonoBehaviour, IAudioPlayer
{
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioSource audioSource;

    public void PlayOneShot(int clipIndex)
    {
        audioSource.PlayOneShot(audioClips[clipIndex]);
    }

    public void Play(int clipIndex)
    {
        audioSource.clip = audioClips[clipIndex];
        audioSource.Play();
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    public void SetLoop(bool isLoop)
    {
        audioSource.loop = isLoop;
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public AudioSource GetAudio()
    {
        return audioSource;
    }
}
