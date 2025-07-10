using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Bar : MonoBehaviour
{
    [SerializeField] Image bar;

    public void Set(float amount)
    {
        if (amount < 0) amount = 0;
        else if (amount > 1) amount = 1;

        bar.GetComponent<RectTransform>().localScale = new Vector3(amount, 1, 1);
    }
}
