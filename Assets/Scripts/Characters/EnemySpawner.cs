using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy EnemyPrefab;

    public Enemy Spawn()
    {
        if (EnemyPrefab == null) return null;

        Enemy enemy = Instantiate(EnemyPrefab, transform.position, transform.rotation);
        return enemy;
    }
}
