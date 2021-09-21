using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public abstract class InGameObjects : MonoBehaviour
{

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        float randomForce = Random.Range(8, 13);
        rb.AddForce(transform.up * randomForce, ForceMode.Impulse);
        
    }


}
