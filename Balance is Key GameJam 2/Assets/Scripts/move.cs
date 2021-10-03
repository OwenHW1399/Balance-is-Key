using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private Rigidbody rb;

    public float thrust = 600f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.Find("Arms"));
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(transform.forward * thrust);
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(transform.right * -thrust);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(transform.forward * -thrust);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(transform.right * thrust);
        
    }
}
