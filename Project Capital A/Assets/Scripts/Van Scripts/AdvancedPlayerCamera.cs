using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedPlayerCamera : MonoBehaviour
{
    //fields
    public float mouseSensitivity = 5f; 
    //represents horizontal rotation
    float pitch;
    //represents vertical rotation
    float yaw;
    //Vector2 used to represent the max vertical rotation
    public Vector2 yawMinMax = new Vector2(-80, 5);
    public Transform target;
    public float distanceFromTarget = 2;

    public float rotationSmoothTime = .12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    public float cameraHeight = 1f;

    public float zoomSpeed = 4f;
    public float minZoom = 3f;
    public float maxZoom = 6f;

    private float currentZoom = 6f;

    public float characterPitch = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        //clamps zoom so it has a min and max value
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }
    // Calls this update after all other updates have been called
    void LateUpdate()
    {
        pitch += Input.GetAxis("Mouse Y") * mouseSensitivity;
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        //sets the restrictions from our pitch based on vector2 values
        pitch = Mathf.Clamp(pitch, yawMinMax.x, yawMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(-pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);

       // Vector3 targetRotation = new Vector3(yaw, pitch);
        transform.eulerAngles = currentRotation;

        Vector3 height = new Vector3(0, cameraHeight, 0);

        transform.position = height + target.position - transform.forward * currentZoom;
        transform.LookAt(target.position + Vector3.up * characterPitch);
    }
}
