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
}
