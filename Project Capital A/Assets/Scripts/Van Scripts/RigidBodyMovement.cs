using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{
    //fields 
    public float speed = 10.0f;
    public Rigidbody rb; 
    public Vector3 movement;
    public Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        //locks and hides cursor to middle of screen, press escape to enable mouse
        Cursor.lockState = CursorLockMode.Locked;
        rb = this.GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        //moveDirection = moveDirection.normalized * speed;
        movement = new Vector3(Input.GetAxis("Vertical")/*Represents W and S movement*/, 0 , -Input.GetAxis("Horizontal")/*Represents A and D movement*/);
    }
    private void FixedUpdate()
    {
        //moves object based on movement
        //which is the vector3 that changes with respect to WASD
        moveCharacter(movement);
        //moveCharacter(moveDirection);
    }
    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
}
