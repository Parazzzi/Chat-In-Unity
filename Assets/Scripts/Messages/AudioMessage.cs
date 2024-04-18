using UnityEngine;

public class AudioMessage : Message
{
    private AudioClip audioClip;
    private AudioSource audioSource;
    private bool isPaused = false;

    public void SetAudio(AudioClip clip)
    {
        audioClip = clip;
    }

    public void OnMessageClicked()
    {
        if (audioSource == null || !audioSource.isPlaying)
        {
            PlayAudio();
            isPaused = false;
        }
        else
        {
            PauseAudio();
            isPaused = true;
        }
    }

    private void PlayAudio()
    {
        if (audioClip != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
    private void PauseAudio()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }
}
