using UnityEngine;

public class SoundSystem : MonoBehaviour, IAudioPlayer
{
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioSource audioSource;

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

    public void PlayOneShot(int clipIndex)
    {
        audioSource.PlayOneShot(audioClips[clipIndex]);
    }

    public void Play(int clipIndex)
    {
        throw new System.NotImplementedException();
    }
}
