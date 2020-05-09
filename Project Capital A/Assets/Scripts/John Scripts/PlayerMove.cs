using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Field
    public Rigidbody rb;
    private float xVel, yVel, zVel;

    // Start is called before the first frame update
    void Start()
    {
        xVel = rb.velocity.x;
        yVel = rb.velocity.y;
        zVel = rb.velocity.z;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Move();
    }

    private Vector3 Move()
    {
        yVel = rb.velocity.y;
        if (Input.GetKey(KeyCode.W))
        {
            zVel = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            zVel = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            xVel = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            xVel = 1;
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            zVel = 0;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            xVel = 0;
        }

        return new Vector3(xVel, yVel, zVel);
    }
}
