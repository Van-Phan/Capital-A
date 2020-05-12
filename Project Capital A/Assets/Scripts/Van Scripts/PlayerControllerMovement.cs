using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMovement : MonoBehaviour
{
    //fields
    public Transform camera;
    public CharacterController player;

    Vector2 input;
    // Start is called before the first frame update
    void Start()
    {
        //locks and hides cursor to middle of screen, press escape to enable mouse
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
