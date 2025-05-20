using UnityEngine;

public interface IAudioPlayer
{
    void PlayOneShot(int clipIndex);
    void Play(int clipIndex);
    void Stop();
    void SetLoop(bool isLoop);
    void SetVolume(float volume);
    AudioSource GetAudio();
}