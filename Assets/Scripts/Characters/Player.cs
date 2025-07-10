using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [field: SerializeField] public PlayerBasket Basket {  get; private set; }
    [field: SerializeField] public SFX_Launcher SFX { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }


    [Header("Object")]
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] private GameObject obj;
    [SerializeField] private Transform firePoint;
    [Space(1)]

    [Header("Launch")]
    [SerializeField] private float chargeRate;
    [SerializeField] private float chargeMaxForce;
    [SerializeField] Vector3 maxLaunchForce = new Vector3(0f, 10f, 30f);
    [SerializeField] Vector3 minLaunchForce = new Vector3(0f, 1f, 1f);
    [SerializeField] private float launchForce;
    [SerializeField] private float leftRightForceMax = 10.0f;
    //[Space(1)]


    [field: SerializeField, Header("Dragging")] public bool IsDragging { get; private set; } = false;
    [SerializeField] Vector3 startPos;
    [SerializeField] float maxDragDistance = -200.0f;
    [SerializeField] float maxLeftRight = 100.0f;

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

        if (IsDragging)
        {
            UI.Debug.DebugText.SetText(DragDifference.ToString());
        }
    }

    #region Charge/Launch
    private void HandleCharge()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            startPos = Input.mousePosition;
            IsDragging = true;



           /* launchForce += Time.deltaTime * chargeRate;
            launchForce = Mathf.Min(launchForce, chargeMaxForce);*/

        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            IsDragging = false;
            LaunchActual();
            /*float normalizedForce = Mathf.Clamp01(launchForce / chargeMaxForce);
            LaunchObject(normalizedForce);*/
        }
    }

    public void LaunchButtonPressed()
    {
        startPos = Input.mousePosition;
        IsDragging = true;
    }

    public void LaunchActual()
    {
        Projectile projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectile.Rigidbody.AddForce(CalculatedLaunchForce(NormalisedForceFromDrag), ForceMode.Impulse);
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

        //isDragging = false;
        launchForce = 0f;
    }

    public Vector3 CalculatedLaunchForce(float normalizedForce)
    {
        Vector3 vector = Vector3.Lerp(minLaunchForce, maxLaunchForce, normalizedForce);
        vector.x = leftRightForceMax * NormalisedLefRight * -1;
        return vector;
    }

    public Vector3 DragDifference
    {
        get
        {
            return Input.mousePosition - startPos;
        }
    }

    public float NormalisedForceFromDrag
    {
        get
        {
            float normalisedForce = 0;

            if (DragDifference.y <= maxDragDistance)
            {
                normalisedForce = 1.0f;
            }
            else if (DragDifference.y > 0)
            {
                normalisedForce = 0.0f;
            }
            else
            {
                normalisedForce = DragDifference.y / maxDragDistance;
            }


            return normalisedForce;
        }
    }

    public float NormalisedLefRight
    {
        get
        {
            if (DragDifference.x > maxLeftRight)
            {
                return 1.0f;
            }
            else if (DragDifference.x < -maxLeftRight)
            {
                return -1.0f;
            }
            else if (DragDifference.x < maxLeftRight && DragDifference.x > 0)
            {
                return DragDifference.x / maxLeftRight;
            }
            else if (DragDifference.x > -maxLeftRight && DragDifference.x < 0)
            {
                return DragDifference.x / -maxLeftRight;
            }
            else
            {
                return 0;
            }
        }
    }

    #endregion
}

//maxLauchForce.z = 30f


//charge shot - https://www.bing.com/videos/riverview/relatedvideo?q=unity+charging+shot&mid=C39AEDEB449F0BEED183C39AEDEB449F0BEED183&FORM=VIRE
//slingshot 1 - https://www.bing.com/videos/riverview/relatedvideo?q=unity+sling+shot&mid=DBE42FD746B9CF2F6C06DBE42FD746B9CF2F6C06&FORM=VIRE
