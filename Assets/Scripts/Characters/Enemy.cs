using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [field: SerializeField] public CapsuleCollider Collider {  get; private set; }
    [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public NavMeshAgent NavMeshAgent { get; private set; }
    [field: SerializeField] public Ragdoll Ragdoll { get; private set; }
    [field: SerializeField] public DeathPause DeathPause { get; private set; }
    [field: SerializeField] public EnemyAI AI { get; private set; }
    [field: SerializeField] public SFX_Enemy SFX { get; private set; }
    [SerializeField] float PostDeathTTL = 15.0f;

    public static event Action OnEnemeyDeath;

    public void BeginDeathPause()
    {
        DeathPause.StartDeathTimer(PostDeathTTL);
        OnEnemeyDeath?.Invoke();
    }

    private void Update()
    {
        Animator.SetBool("moving", NavMeshAgent.velocity.magnitude > 0);


    }
}