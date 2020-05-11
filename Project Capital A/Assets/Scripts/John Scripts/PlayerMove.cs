using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Field
    public Rigidbody rb;
    private float xVel, yVel, zVel;
    private bool isNotJumping;

    // Start is called before the first frame update
    void Start()
    {
        xVel = rb.velocity.x;
        yVel = rb.velocity.y;
        zVel = rb.velocity.z;
        isNotJumping = true;
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
            zVel = 3;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            zVel = -3;
        }

        if (Input.GetKey(KeyCode.A))
        {
            xVel = -3;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            xVel = 3;
        }

		if (Input.GetKeyDown(KeyCode.Space) && isNotJumping)
		{
            yVel = 10;
            isNotJumping = false;
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
