using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] RectTransform mainMenu;
    [SerializeField] RectTransform scoreMenu;

    private void Start()
    {
        scoreMenu.gameObject.SetActive(false);
    }

    public void PlayButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }

    public void ShowHighscore()
    {
        scoreMenu.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }

    public void HideHighscore()
    {
        scoreMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }
}


//scene index 0 menu, 1 game