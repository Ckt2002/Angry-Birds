public class SlingShotSoundController : SoundController
{
    bool isPlayed = false;

    public override void PlayAudio(int clipIndex)
    {
        if (!isPlayed)
        {
            audioSource.clip = audioClips[clipIndex];
            audioSource.Play();
            isPlayed = true;
        }
    }

    public override void ResetAudio() => isPlayed = false;
}
