using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_NameQuestion : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;

    public void OnEnterPress()
    {
        Highscore.Save(inputField.text, Game.Instance.Score);
        BackToMenu.ReturnToMenu();
    }
}
