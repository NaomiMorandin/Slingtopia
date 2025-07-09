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
        enemy.Animator.enabled = false;

        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.isKinematic = false;
        }

        foreach (Collider collider in ragdollColliders)
        {
            collider.enabled = true;
        }
    }

    public void TurnOff()
    {
        enemy.Animator.enabled = true;

        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.isKinematic = true;
        }

        foreach (Collider collider in ragdollColliders)
        {
            collider.enabled = false;
        }
    }
}
