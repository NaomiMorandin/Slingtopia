using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            ReturnToMenu();
        }
    }

    public static void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
