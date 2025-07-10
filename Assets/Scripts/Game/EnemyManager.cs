using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    EnemySpawner[] enemySpawners;

    [SerializeField] int[] enemyTargets;

    int enemyCount;

    private void Awake()
    {
        enemySpawners = FindObjectsOfType<EnemySpawner>();
    }

    private void OnEnable()
    {
        Enemy.OnEnemeyDeath += OnEnemyDeath;
    }

    private void OnDisable()
    {
        Enemy.OnEnemeyDeath -= OnEnemyDeath;
    }

    private void Update()
    {
        if (enemyCount < enemyTargets[Game.Instance.Level])
        {
            EnemySpawner spawner = null;

            int attempt = 0;

            while ((spawner == null || !spawner.IsReady) && attempt < 5)
            {
                spawner = enemySpawners[Random.Range(0, enemySpawners.Length)];
                attempt++;
            }

            if (spawner != null && spawner.IsReady)
            {
                Enemy enemy = spawner.Spawn();
                if (enemy != null)
                {
                    enemyCount++;
                }
            }
        }
    }

    private void OnEnemyDeath()
    {
        enemyCount--;
    }
}
