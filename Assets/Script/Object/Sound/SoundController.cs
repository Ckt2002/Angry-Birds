using UnityEngine;

public abstract class SoundController : MonoBehaviour
{
    [SerializeField] protected AudioClip[] audioClips;

    protected AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void PlayAudio(int clipIndex)
    {
        audioSource.PlayOneShot(audioClips[clipIndex]);
    }

    public virtual void StopAudio()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();
    }

    public virtual void ResetAudio() { }
}
