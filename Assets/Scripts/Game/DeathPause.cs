using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPause : MonoBehaviour
{
    float timer;

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void StartDeathTimer(float timeToLive)
    {
        if (timer != 0) return;

        timer = timeToLive;
    }
}
