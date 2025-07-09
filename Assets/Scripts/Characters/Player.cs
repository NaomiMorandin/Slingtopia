using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] private GameObject obj;
    [Space(1)]

    [Header("Launch")]
    [SerializeField] private float chargeRate;
    //[SerializeField] private float chargeMax;
    [SerializeField] private float launchForce;
    [Space(1)]

    [Header("Dragging")]
    [SerializeField] private bool isDragging;
    private Camera cam;
    private float startXPos;
    private float startYPos;

    private void Start()
    {
        cam = Camera.main;

        if(obj == null)
        {
            Debug.LogError("No Object Found!");
            return;
        }
    }


    private void Update()
    {
        HandleCharge();

        if(isDragging)
        {
            HandleDrag();
        }
    }

    #region Charge/Launch
    private void HandleCharge()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            isDragging = true;
            launchForce += Time.deltaTime * chargeRate;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {

            LaunchObject();
        }
    }

    private void LaunchObject()
    {
        var launchedObject = Instantiate(obj, transform.position, transform.rotation);
        var rb = launchedObject.GetComponent<Rigidbody>();
 
        if(rb != null )
        {
            rb.AddForce(Vector3.forward * (10f * launchForce), ForceMode.Impulse);
        }

        isDragging = false;
        launchForce = 0f;
    }
    #endregion

    #region Drag
    private void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = cam.ScreenToWorldPoint(mousePos);

        startXPos = mousePos.x - transform.localPosition.x;
        startYPos = mousePos.y - transform.localPosition.y;

        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void HandleDrag()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = cam.ScreenToWorldPoint(mousePos);
        transform.localPosition = new Vector3(mousePos.x - startXPos,
            mousePos, mousePose.y - startYPos, transform.localPosition.z);
    }
    #endregion
}

//input
//power up shot
//dragging
//applying force to object when let go


//charge shot - https://www.bing.com/videos/riverview/relatedvideo?q=unity+charging+shot&mid=C39AEDEB449F0BEED183C39AEDEB449F0BEED183&FORM=VIRE
//slingshot 1 - https://www.bing.com/videos/riverview/relatedvideo?q=unity+sling+shot&mid=DBE42FD746B9CF2F6C06DBE42FD746B9CF2F6C06&FORM=VIRE
