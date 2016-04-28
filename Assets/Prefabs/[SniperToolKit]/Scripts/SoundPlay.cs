using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundPlay : MonoBehaviour {

    AudioSource source;

    public void OnEnable()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        if (source) source.PlayOneShot(clip);
    }

    public void StopSound()
    {
        if (source) source.Stop();
    }
}
