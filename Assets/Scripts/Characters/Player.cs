using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] private GameObject obj;
    [SerializeField] private Transform firePoint;
    [Space(1)]

    [Header("Launch")]
    [SerializeField] private float chargeRate;
    [SerializeField] private float chargeMaxForce;
    [SerializeField] Vector3 maxLaunchForce = new Vector3(0f, 0f, 10f);
    [SerializeField] Vector3 minLaunchForce = new Vector3(0f, 0f, 1f);
    [SerializeField] private float launchForce;
    [Space(1)]

    [Header("Dragging")]
    [SerializeField] private bool isDragging;

    private void Start()
    {

        if (obj == null)
        {
            Debug.LogError("No Object Found!");
            return;
        }
    }


    private void Update()
    {
        HandleCharge();
    }

    #region Charge/Launch
    private void HandleCharge()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            isDragging = true;
            launchForce += Time.deltaTime * chargeRate;
            launchForce = Mathf.Min(launchForce, chargeMaxForce);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            float normalizedForce = Mathf.Clamp01(launchForce / chargeMaxForce);
            LaunchObject(normalizedForce);
        }
    }

    private void LaunchObject(float normal)
    {
        var launchedObject = Instantiate(obj, firePoint.position, Quaternion.identity);
        var rb = launchedObject.GetComponent<Rigidbody>();
 
        if(rb != null )
        {
            Vector3 calcForce = CalculatedLaunchForce(normal);
            Vector3 launchDir = Vector3.forward * calcForce.z + Vector3.up * (calcForce.z * .5f);
            rb.AddForce(launchDir, ForceMode.Impulse);
        }

        isDragging = false;
        launchForce = 0f;
    }

    public Vector3 CalculatedLaunchForce(float normalizedForce)
    {
        return Vector3.Lerp(minLaunchForce, maxLaunchForce, normalizedForce);
    }

    #endregion
}

//maxLauchForce.z = 30f


//charge shot - https://www.bing.com/videos/riverview/relatedvideo?q=unity+charging+shot&mid=C39AEDEB449F0BEED183C39AEDEB449F0BEED183&FORM=VIRE
//slingshot 1 - https://www.bing.com/videos/riverview/relatedvideo?q=unity+sling+shot&mid=DBE42FD746B9CF2F6C06DBE42FD746B9CF2F6C06&FORM=VIRE
