using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyRotation : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float torqueMin;
    [SerializeField] private float torqueMax;
    private float torque;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        float randomValue = Random.Range(torqueMin, torqueMax);
        torque = randomValue;
    }

    private void FixedUpdate()
    {
        ApplyRBRotation();
    }

    private void ApplyRBRotation()
    {
        rb.AddTorque(transform.right * torque);
        rb.AddTorque(transform.forward * torque);
    }
}
