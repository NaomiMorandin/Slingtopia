using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy EnemyPrefab;
    [SerializeField] float cooldown = 1.0f;

    float timer;

    private void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
    }

    public Enemy Spawn()
    {
        if (EnemyPrefab == null || timer > 0) return null;
        timer = cooldown;
        Enemy enemy = Instantiate(EnemyPrefab, transform.position, transform.rotation);
        return enemy;
    }

    public bool IsReady => timer <= 0;
}
