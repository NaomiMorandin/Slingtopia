using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSelector : MonoBehaviour
{
    [SerializeField] GameObject[] Models;

    private void Start()
    {
        if (Models.Length > 0)
        {
            foreach (GameObject model in Models)
            {
                model.SetActive(false);
            }

            int random = Random.Range(0, Models.Length);
            Models[random].SetActive(true);
        }
        
    }
}
