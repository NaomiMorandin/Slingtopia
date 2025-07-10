using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Enemy : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] getHitSounds;
    [SerializeField] AudioClip[] trenchArriveSounds;

    public void PlayGetHitSound()
    {
        if (audioSource == null || getHitSounds.Length == 0) return;

        if (!audioSource.isPlaying) audioSource.Stop();
        audioSource.clip = getHitSounds[Random.Range(0, getHitSounds.Length)];
        audioSource.Play();
    }

    public void PlayTrenchArriveSound()
    {
        if (audioSource == null || trenchArriveSounds.Length == 0) return;

        if (!audioSource.isPlaying) audioSource.Stop();
        audioSource.clip = trenchArriveSounds[Random.Range(0, trenchArriveSounds.Length)];
        audioSource.Play();
    }
}
