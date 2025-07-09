using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI Instance;

    [SerializeField] UI_Debug debug;

    public static UI_Debug Debug => Instance.debug;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }

    public void OnLaunchButtonPress()
    {
        print("launc button press");
        Player.Instance.LaunchButtonPressed();
    }
}
