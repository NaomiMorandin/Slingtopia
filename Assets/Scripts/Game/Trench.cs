using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trench : MonoBehaviour
{
    [SerializeField] int MaxEnemyCount = 100;
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
            enemy.Ragdoll.ApplyForce((enemy.transform.forward * deathForce) + (enemy.transform.up * (deathForce/2)));
            enemy.SFX.PlayTrenchArriveSound();

            EnemyCount++;

            if (EnemyCount >= MaxEnemyCount)
            {
                //BackToMenu.ReturnToMenu();
                Game.Instance.IsRunning = false;
                UI.NameQuestion.gameObject.SetActive(true);
            }
        }
    }
    public float Progress
    {
        get
        {
            return (float)EnemyCount / (float)MaxEnemyCount;
        }
    }
}
