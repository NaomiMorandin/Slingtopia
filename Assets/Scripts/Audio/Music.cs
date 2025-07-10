using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] musicClips;
    int index = -1;

    private void Update()
    {
        if (audioSource == null && !audioSource.isPlaying && musicClips.Length > 0 && index < musicClips.Length)
        {
            index++;

            audioSource.clip = musicClips[index];
            audioSource.Play();
        }
    }
}
