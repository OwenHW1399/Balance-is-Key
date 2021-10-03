using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Script to controll a player with a rigidbody component
public class RigidbodyController : MonoBehaviour
{
    public float Acceleration = 50f; // net force increase per FixedUpdate call
    public float TurnSpeed = 2f; // turn speed in radians/second

    [Range(1,4)] // lets you restrict the player number in the unity editor
    public int player = 1;

    private string _hAxis;
    private string _vAxis;
    private Rigidbody rb;

    private Vector3 _input = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _hAxis = "p" + player + "Horizontal";
        _vAxis = "p" + player + "Vertical";
    }

    void Update()
    {
        _input = Vector3.zero;
        _input.x = Input.GetAxis(_hAxis);
        _input.z = Input.GetAxis(_vAxis);
    }

    // FixedUpdate is not affected by framerate, it is called at a fixed time interval so may be called 0, 1, or more times per depending on the current framerate
    void FixedUpdate()
    {
        rb.AddForce(_input * Acceleration, ForceMode.Force); // adjust the net force vector every frame by adding a force in the direction of the user input
    }
}
