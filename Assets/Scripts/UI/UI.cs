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
    [SerializeField] UI_Bar trenchBar;

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
            int seconds = (int)Game.GameTime;
            int minutes = 0;

            while (seconds > 60)
            {
                seconds -= 60;
                minutes++;
            }

            time.SetText(minutes.ToString() + ":" + seconds.ToString("d2"));
        }

        if (score != null)
        {
            score.SetText(Game.Instance.Score.ToString());
        }

        if (enemyCount != null)
        {
            enemyCount.SetText(Game.Instance.Trench.EnemyCount.ToString());
        }

        if (trenchBar != null)
        {
            trenchBar.Set(Game.Instance.Trench.Progress);
        }
    }

    public void OnLaunchButtonPress()
    {
        print("launc button press");
        Player.Instance.LaunchButtonPressed();
    }
}
