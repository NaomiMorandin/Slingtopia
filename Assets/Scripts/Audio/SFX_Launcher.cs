using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Launcher : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip stretchingSound;
    [SerializeField] AudioClip[] launchSound;
    [SerializeField] float pitchVariation = 0.1f;

    public void PlayStrechSound()
    {
        if (stretchingSound == null || audioSource == null) return;

        if (audioSource.isPlaying) audioSource.Stop();
        audioSource.clip = stretchingSound;
        audioSource.pitch = Random.Range(1 - pitchVariation, 1 + pitchVariation);
        audioSource.Play();
    }

    public void PlayLaunchSound()
    {
        if (launchSound.Length == 0 || audioSource == null) return;

        if (audioSource.isPlaying) audioSource.Stop();
        audioSource.clip = launchSound[Random.Range(0, launchSound.Length)];
        audioSource.pitch = Random.Range(1 - pitchVariation, 1 + pitchVariation);
        audioSource.Play();
    }
}
