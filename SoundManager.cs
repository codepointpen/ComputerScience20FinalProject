using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }

    private AudioSource source; // the audio clip

    private void Awake() // gets the audio source
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound) // plays the audio
    {
        source.PlayOneShot(sound);
    }
}
