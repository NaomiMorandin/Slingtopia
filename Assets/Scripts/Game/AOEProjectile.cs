using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEProjectile : MonoBehaviour
{
    [field: SerializeField] public Collider Collider { get; private set; }
    [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
    [field: SerializeField] public DeathPause DeathPause { get; private set; }
    [SerializeField] float PostDeathTTL = 15.0f;

    [SerializeField] AudioClip[] impactClip;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject impactEffect;
    [SerializeField] int ScorePerHit = 10;

    [Header("AOE")]
    [SerializeField] private float radius;


    private void Start()
    {
        impactEffect.SetActive(true);
    }

    private void OnCollisionEnter(Collision col)
    {

    }

    public void PlayImpactSound()
    {
        if (audioSource != null && impactClip.Length > 0)
        {
            if (audioSource.isPlaying) audioSource.Stop();
            audioSource.clip = impactClip[Random.Range(0, impactClip.Length)];
            audioSource.Play();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
