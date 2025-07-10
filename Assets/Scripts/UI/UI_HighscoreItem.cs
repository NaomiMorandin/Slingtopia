using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Highscore;

public class UI_HighscoreItem : MonoBehaviour
{
    [SerializeField] TMP_Text scoreName;
    [SerializeField] TMP_Text score;

    public void Set(PlayerScore playerScore)
    {
        scoreName.SetText(playerScore.Name);
        score.SetText(playerScore.Score.ToString());
    }
}
