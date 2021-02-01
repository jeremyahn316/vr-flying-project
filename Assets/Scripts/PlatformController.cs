using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour 
{

   

    public Transform[] destinations;

    public float speed = 2;

    bool isMoving = false;

    private int curr;

	// Use this for initialization
	void Start () 
    {
        transform.position = destinations[0].position;

        curr = 1;
    }

    // Update is called once per frame
    void Update () 
    {
        HandleInput();

        HandleMovement();
    }

    void HandleInput()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            isMoving = !isMoving;
        }
    }

    void HandleMovement()
    {

        if (!isMoving) return;

        float distance = Vector3.Distance(transform.position, destinations[curr].position);

        if (distance > 0)
        {

            float step = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, destinations[curr].position, step);
        }
        else
        {
            curr++;

            if (curr == destinations.Length)
            {
                curr = 0;
            }

            isMoving = false;
        }

    }
}
