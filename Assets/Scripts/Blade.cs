using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject bladeTrailPrefab;

    [SerializeField] private float minCuttingVelocity;
    private bool isCutting = false;
    private Vector2 previousPosition;
    private GameObject currentBladeTrail;
    private Rigidbody rb;
    private Camera cam;
    private SphereCollider sphereCollider;

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.enabled = false;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
    }

    private void Update()
    {
        

        foreach (Touch touch in Input.touches)
        {
            
            if (touch.phase == TouchPhase.Began)
            {
                isCutting = true;
                currentBladeTrail.SetActive(true);
                previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
                sphereCollider.enabled = false;
            }

            else if(touch.phase == TouchPhase.Moved)
            {
                UpdateCutMobile(touch.position);
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                isCutting = false;
                
                currentBladeTrail.SetActive(false);
                sphereCollider.enabled = false;
            }
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }

        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }
        
        if (isCutting)
        {
            UpdateCutPC();
        }
    }

    private void UpdateCutPC()
    {
        Vector2 newPos = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPos;

        float velocity = (newPos - previousPosition).magnitude * Time.deltaTime;
        
        if(velocity > minCuttingVelocity)
        {
            sphereCollider.enabled = true;
        }
        else
        {
            sphereCollider.enabled = false;
        }

        previousPosition = newPos;
    }

    private void UpdateCutMobile(Vector2 input)
    {
        Vector2 newPos = cam.ScreenToWorldPoint(input);
        rb.position = newPos;

        float velocity = (newPos - previousPosition).magnitude / Time.deltaTime;
        if (velocity > minCuttingVelocity)
        {
            sphereCollider.enabled = true;
        }
        else
        {
            sphereCollider.enabled = false;
        }

        previousPosition = newPos;
    }

    void StartCutting()
    {
        isCutting = true;
        
        currentBladeTrail.SetActive(true);
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        sphereCollider.enabled = false;
    }

    void StopCutting()
    {
        isCutting = false;
        currentBladeTrail.SetActive(false);
        sphereCollider.enabled = false;
        currentBladeTrail.GetComponent<TrailRenderer>().Clear();
    }


}
