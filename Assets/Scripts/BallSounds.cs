using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSounds : MonoBehaviour
{
    private SoundManager sm;

    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Ball touched the ground");
            // TODO: show message telling player to restart from checkpoint
            sm.PlayBallLandSoft();
        }
    }
}
