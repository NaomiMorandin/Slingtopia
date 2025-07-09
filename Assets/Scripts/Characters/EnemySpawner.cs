using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy EnemyPrefab;

    public void Spawn()
    {
        if (EnemyPrefab == null) return;

        Enemy enemy = Instantiate(EnemyPrefab, transform.position, transform.rotation);
    }
}
