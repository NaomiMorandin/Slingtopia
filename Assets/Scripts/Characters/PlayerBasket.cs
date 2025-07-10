using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasket : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Transform basket;

    [SerializeField] Vector3 restPos;
    [SerializeField] Vector3 minPos;
    [SerializeField] Vector3 maxPos;
    [SerializeField] float maxLeftRight;

    private void Update()
    {
        if (player.IsDragging) basket.localPosition = LocalPos;
        else basket.localPosition = restPos;
    }

    private Vector3 LocalPos
    {
        get
        {
            Vector3 pos = Vector3.Lerp(minPos, minPos, player.NormalisedForceFromDrag);
            pos.x = maxLeftRight * player.NormalisedLefRight;
            return pos;
        }
    }
}
