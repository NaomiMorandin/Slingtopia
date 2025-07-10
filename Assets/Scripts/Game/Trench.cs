using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trench : MonoBehaviour
{
    [field: SerializeField] public int EnemyCount { get; private set; } = 0;
    [SerializeField] float deathForce = 10;

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            print("Enemy hit trench");

            enemy.Ragdoll.TurnOn();
            enemy.BeginDeathPause();
            enemy.Ragdoll.ApplyForce(enemy.transform.forward * deathForce);

            EnemyCount++;
        }
    }
}
