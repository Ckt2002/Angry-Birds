using UnityEngine;

public class SoundUI : MonoBehaviour, IAudioPlayer
{
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioSource audioSource;

    public void PlayOneShot(int clipIndex)
    {
        audioSource.PlayOneShot(audioClips[clipIndex]);
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

    public void Play(int clipIndex)
    {
        throw new System.NotImplementedException();
    }
}
