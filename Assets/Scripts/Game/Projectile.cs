using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [field: SerializeField] public Collider Collider { get; private set; }
    [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
    [field: SerializeField] public DeathPause DeathPause { get; private set; }
    [SerializeField] float PostDeathTTL = 15.0f;

    [SerializeField] AudioClip[] impactClip;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject impactEffect;
    [SerializeField] int ScorePerHit = 10;

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            print("Hit Enemy");

            enemy.Ragdoll.TurnOn();
            enemy.BeginDeathPause();

            if (impactEffect != null) Instantiate(impactEffect, transform.position, transform.rotation);
            PlayImpactSound();
            Game.Instance.Score += ScorePerHit;
        }
        
        DeathPause.StartDeathTimer(PostDeathTTL);
    }
    //comment
    public void PlayImpactSound()
    {
        if (audioSource != null && impactClip.Length > 0)
        {
            if (audioSource.isPlaying) audioSource.Stop();
            audioSource.clip = impactClip[Random.Range(0, impactClip.Length)];
            audioSource.Play();
        }
    }
}
