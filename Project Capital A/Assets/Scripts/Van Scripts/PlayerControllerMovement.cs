using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMovement : MonoBehaviour
{
    //fields
    public Transform camera;
    public CharacterController player;

    private float verticalVelocity;
    private float gravity = 9.81f;
    private float jumpForce = 10.0f;

    public float walkSpeed = 2;
    public float runSpeed = 6;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;


    Vector2 input;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        player = GetComponent<CharacterController>();
        //locks and hides cursor to middle of screen, press escape to enable mouse
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //if the player is on the ground apply a downwards velocity
        if (player.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            //if the player presses space while they are grounded they jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else 
        //if the player is not grounded then they are falling
        //so we mimic downwards acceleration by decrementing it
        {
            //determines the speed our character falls
            verticalVelocity -= (gravity + 2) * Time.deltaTime;
        }
        //moves the player in the vertical direction
        Vector3 verticalVector = new Vector3(0, verticalVelocity, 0);

        //determines which way the user wants to go based off WASD input
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //normalizes our vector so if moving diagonally we don't move faster
        input = input.normalized;

        //sets up rotation of object
        if(input != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + camera.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        //determine if the user is holding download left shift to run
        bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed;
        if (running)
        {
            targetSpeed = runSpeed * input.magnitude;
        }
        else
        {
            targetSpeed = walkSpeed * input.magnitude;
        }
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        //creates a velocity vector which also corresponds with speed
        Vector3 velocity = transform.forward * currentSpeed;
        //adds the vertical component to the movement
        Vector3 movement = verticalVector + velocity;
        //moves players based on movement
        player.Move(movement * Time.deltaTime);
    }
}
