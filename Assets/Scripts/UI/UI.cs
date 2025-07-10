using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI Instance;

    [SerializeField] UI_Debug debug;
    [SerializeField] TMP_Text time;
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text enemyCount;

    public static UI_Debug Debug => Instance.debug;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }

    private void Update()
    {
        if (time != null)
        {
            time.SetText(Game.GameTime.ToString("f0"));
        }

        if (score != null)
        {
            score.SetText(Game.Instance.Score.ToString());
        }

        if (enemyCount != null)
        {
            enemyCount.SetText(Game.Instance.Trench.EnemyCount.ToString());
        }
    }

    public void OnLaunchButtonPress()
    {
        print("launc button press");
        Player.Instance.LaunchButtonPressed();
    }
}
