using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour
{

    public float speed = 2;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb.angularVelocity= Vector3()
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.hasChanged)
        {
            
        }
    }
}
