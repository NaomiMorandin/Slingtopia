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
    [SerializeField] private float minForce;
    [SerializeField] private float launchForce;
    [Space(1)]

    [Header("Dragging")]
    [SerializeField] private bool isDragging;
    private Camera cam;
    private float startXPos;
    private float startYPos;

    private Vector3 mousePos;
    private Vector3 objectVector;

    private void Start()
    {
        cam = Camera.main;
        mousePos = Input.mousePosition;

        if (obj == null)
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
            DragObject();
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
            LaunchObject(objectVector);
        }
    }

    private void LaunchObject(Vector3 pos)
    {
        var launchedObject = Instantiate(obj, pos, Quaternion.identity);
        var rb = launchedObject.GetComponent<Rigidbody>();
 
        if(rb != null )
        {
            rb.AddForce(Vector3.forward * (minForce * launchForce), ForceMode.Impulse);
        }

        isDragging = false;
        launchForce = 0f;
    }
    #endregion
    #region Drag
    private void OnMouseDown()
    {
        mousePos = cam.ScreenToWorldPoint(mousePos);

        startXPos = mousePos.x - transform.localPosition.x;
        startYPos = mousePos.y - transform.localPosition.y;

        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private Vector3 DragObject()
    {
        mousePos = cam.ScreenToWorldPoint(mousePos);
        var objectVector = obj.transform.localPosition;
        objectVector = new Vector3(mousePos.x - startXPos,
            mousePos.y - startYPos, transform.localPosition.z);

        return objectVector;

    }
    #endregion

}

//input
//power up shot
//dragging
//applying force to object when let go


//charge shot - https://www.bing.com/videos/riverview/relatedvideo?q=unity+charging+shot&mid=C39AEDEB449F0BEED183C39AEDEB449F0BEED183&FORM=VIRE
//slingshot 1 - https://www.bing.com/videos/riverview/relatedvideo?q=unity+sling+shot&mid=DBE42FD746B9CF2F6C06DBE42FD746B9CF2F6C06&FORM=VIRE
