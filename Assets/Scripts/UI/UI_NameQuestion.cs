using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_NameQuestion : MonoBehaviour
{
    [SerializeField] InputField inputField;

    public void OnEnterPress()
    {
        Highscore.Save(inputField.text, Game.Instance.Score);
        BackToMenu.ReturnToMenu();
    }
}
