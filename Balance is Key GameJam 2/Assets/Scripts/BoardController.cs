using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    Rigidbody myRigidbody;

    private float movementSpeed = 5.0f;
    private float smooth = 0.02f;
    public KeyCode keyMoveRight = KeyCode.D;
    public KeyCode keyMoveLeft = KeyCode.A;
    public KeyCode keyMoveForward = KeyCode.W;
    public KeyCode keyMoveBackward = KeyCode.S;

    public float shiftingSpeed = 1.0f;
    // public float shiftingLimit = 15.0f;
    public KeyCode keyShiftUp = KeyCode.UpArrow;
    public KeyCode keyShiftRight = KeyCode.RightArrow;
    public KeyCode keyShiftDown = KeyCode.DownArrow;
    public KeyCode keyShiftLeft = KeyCode.LeftArrow;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
    
    // void Update ()
    // {
    //     RaycastHit hit;
    //     if (Physics.Raycast (transform.position, -Vector3.up)) {
    //         var distanceToGround = hit.distance;
    //         //use below code if your pivot point is in the middle
    //         transform.position.y = hit.distance - GetComponent<Collider>().bounds.extents;
    //         //use below code if your pivot point is at the bottom
    //         //transform.position.y = hit.distance;
    //     }
    // }


    // got it from the internet
    public static Quaternion ClampRotation(Quaternion q, Vector3 bounds)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;
    
        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
        angleX = Mathf.Clamp(angleX, -bounds.x, bounds.x);
        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);
    
        float angleY = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.y);
        angleY = Mathf.Clamp(angleY, -bounds.y, bounds.y);
        q.y = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleY);
    
        float angleZ = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.z);
        angleZ = Mathf.Clamp(angleZ, -bounds.z, bounds.z);
        q.z = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleZ);
    
        return q;
    }

    void FixedUpdate()
    {
        // shift the board
        float shiftingSpeedInFrame = shiftingSpeed;

        if (Input.GetKey(keyShiftUp))
            transform.Rotate(shiftingSpeedInFrame, 0.0f, 0.0f);
        else if (Input.GetKey(keyShiftDown))
            transform.Rotate(-shiftingSpeedInFrame, 0.0f, 0.0f);
        else
            transform.Rotate(0.0f, 0.0f, transform.rotation.z);
        if (Input.GetKey(keyShiftLeft))
            transform.Rotate(0.0f, 0.0f, shiftingSpeedInFrame);
        else if (Input.GetKey(keyShiftRight))
            transform.Rotate(0.0f, 0.0f, -shiftingSpeedInFrame);
        else
            transform.Rotate(transform.rotation.z, 0.0f, 0.0f);

        if (!Input.GetKey(keyShiftUp) && !Input.GetKey(keyShiftDown) && !Input.GetKey(keyShiftLeft)
            && !Input.GetKey(keyShiftRight))
        {
            Quaternion target = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, smooth);
        }

        // make sure the board doesn't rotate too much
        // transform.rotation = ClampRotation(transform.rotation, new Vector3(shiftingLimit, shiftingLimit, shiftingLimit));

        GameObject stairs = GameObject.Find("stairs_main_body");

        transform.position = new Vector3(transform.position.x, stairs.transform.position.y + 8.0f, transform.position.z);

        // move the board
        float movementSpeedInFrame = movementSpeed;

        if (Input.GetKey(keyMoveForward))
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, myRigidbody.velocity.y, movementSpeedInFrame);
        else if (Input.GetKey(keyMoveBackward))
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, myRigidbody.velocity.y, -movementSpeedInFrame);
        else
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, myRigidbody.velocity.y, 0.0f);

        if (Input.GetKey(keyMoveLeft))
            myRigidbody.velocity = new Vector3(-movementSpeedInFrame, myRigidbody.velocity.y, myRigidbody.velocity.z);
        else if (Input.GetKey(keyMoveRight))
            myRigidbody.velocity = new Vector3(movementSpeedInFrame, myRigidbody.velocity.y, myRigidbody.velocity.z);
        else
            myRigidbody.velocity = new Vector3(0.0f, myRigidbody.velocity.y, myRigidbody.velocity.z);
    }
}