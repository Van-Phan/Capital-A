using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayerController : MonoBehaviour
{
    //fields
    public Transform camera;
    public CharacterController player;

    private float verticalVelocity;
    private float gravity = 9.81f;
    private float jumpForce = 6.0f;

    Vector2 input;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        //locks and hides cursor to middle of screen, press escape to enable mouse
        Cursor.lockState = CursorLockMode.Locked;
    }

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
        else //if the player is not grounded then they are falling
        //so we mimic downwards acceleration 
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        //moves the player in the vertical direction
        Vector3 verticalVector = new Vector3(0, verticalVelocity, 0);
        verticalVector = verticalVector.normalized;

        //determines which way the user wants to go based off WASD input
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //normalizes our vector so if moving diagonally we don't move faster
        input = input.normalized;

        //retrieves the vectors of our camera
        Vector3 cameraForward = camera.forward;
        Vector3 cameraRight = camera.right;

        //eliminates y vector since camera is rotated to look down slightly
        cameraForward.y = 0;
        cameraRight.y = 0;

        //moves the player 
        player.Move((cameraForward * input.y + cameraRight * input.x) * Time.deltaTime * 5);
        Vector3 movement = (cameraForward * input.y + cameraRight * input.x + verticalVector);
        player.Move(movement * Time.deltaTime * 5);
    }
}
