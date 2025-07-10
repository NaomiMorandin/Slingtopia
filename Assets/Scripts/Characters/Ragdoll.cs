using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] Rigidbody[] ragdollRigidbodies;
    [SerializeField] Collider[] ragdollColliders;

    private void Start()
    {
        TurnOff();
    }

    public void TurnOn()
    {
        enemy.Animator.applyRootMotion = false;
        enemy.Animator.enabled = false;
        enemy.Collider.enabled = false;
        enemy.NavMeshAgent.enabled = false;
        enemy.AI.enabled = false;

        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.isKinematic = false;

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

        }

        foreach (Collider collider in ragdollColliders)
        {
            collider.enabled = true;
        }

    }

    public void TurnOff()
    {
        enemy.Animator.enabled = true;
        enemy.Collider.enabled = true;
        

        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.isKinematic = true;
        }

        foreach (Collider collider in ragdollColliders)
        {
            collider.enabled = false;
        }
    }

    public void ApplyForce(Vector3 force)
    {
        ragdollRigidbodies[0].AddForce(force, ForceMode.VelocityChange);
    }
}
