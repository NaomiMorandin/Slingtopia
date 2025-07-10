using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineRender : MonoBehaviour
{
    [Header("String")]
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;


    [SerializeField] private LineRenderer lineRenderer;


    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    private void Update()
    {
        if (startPoint && endPoint != null)
        {
            lineRenderer.SetPosition(0, startPoint.position);
            lineRenderer.SetPosition(1, endPoint.position);
        }

    }
}
