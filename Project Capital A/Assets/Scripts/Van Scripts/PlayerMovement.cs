using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10;
    public float turningSpeed = 60;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);
    }
}
