using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    [field: SerializeField] public Trench Trench { get; private set; }
    [field: SerializeField] public EnemySpawner[] Spawners { get; private set; }
    float gameTime;
    public int Score;

    public static float GameTime => Instance.gameTime;
    public bool IsRunning = true;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);

        if (Trench == null) Trench = FindFirstObjectByType<Trench>();
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
    }

    public int Level
    {
        get
        {
            int l = (int)(gameTime / 30);
            if (l > 10) return 10;
            return l;
        }
    }

}
