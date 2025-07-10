using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] float wonderingRadius;

    [field: SerializeField] public AI_State CurrentState { get; private set; } 

    public enum AI_State
    {
        Idle,
        RandomWondering,
        AdvancingToTrench
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (CurrentState == AI_State.RandomWondering)
        {
            if (enemy.NavMeshAgent.velocity.magnitude == 0)
            {
                enemy.NavMeshAgent.SetDestination(RandomPointOnNavMesh);
            }
        }

        else if (CurrentState == AI_State.AdvancingToTrench)
        {
            if (enemy.NavMeshAgent.velocity.magnitude == 0)
            {
                enemy.NavMeshAgent.SetDestination(Game.Instance.Trench.transform.position);
            }
        }
    }

    public void SetNewState(AI_State newState)
    {
        CurrentState = newState;
    }


    public Vector3 RandomPointOnNavMesh
    {
        get
        {
            for (int i = 0; i < 30; i++) // Try up to 30 times
            {
                Vector3 randomDirection = Random.insideUnitSphere * wonderingRadius;
                randomDirection += transform.position;

                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomDirection, out hit, wonderingRadius, NavMesh.AllAreas))
                {
                    return hit.position;
                }
            }

            // Fallback if no point found
            return transform.position;
        }
    }

}
