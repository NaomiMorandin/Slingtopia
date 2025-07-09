using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [field: SerializeField] public Collider Collider { get; private set; }
    [field: SerializeField] public Rigidbody Rigidbody { get; private set; }


    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            print("Hit Enemy");
        }

        Destroy(this.gameObject);
    }
}
