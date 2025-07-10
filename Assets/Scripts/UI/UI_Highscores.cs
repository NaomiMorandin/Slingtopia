using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Highscore;

public class UI_Highscores : MonoBehaviour
{
    [SerializeField] Menu menu;
    [SerializeField] Transform content;
    [SerializeField] UI_HighscoreItem highscoreItemPrefabs;

    List<UI_HighscoreItem> list = new List<UI_HighscoreItem>();

    private void OnEnable()
    {
        ClearList();
        PopulateList();
    }

    private void PopulateList()
    {
        foreach (PlayerScore pScore in Highscore.Load())
        {
            UI_HighscoreItem hsItem = Instantiate<UI_HighscoreItem>(highscoreItemPrefabs, content);
            hsItem.Set(pScore);
            list.Add(hsItem);
        }
    }

    private void OnDisable()
    {
        ClearList();
    }

    private void ClearList()
    {
        if (list.Count > 0)
        {
            foreach (UI_HighscoreItem item in list)
            {
                Destroy(item.gameObject);
            }
            list.Clear();
        }
    }

    public void OnBackButtonPress()
    {
        menu.HideHighscore();
    }
}
