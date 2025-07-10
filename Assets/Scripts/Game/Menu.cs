using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }
}


//scene index 0 menu, 1 game