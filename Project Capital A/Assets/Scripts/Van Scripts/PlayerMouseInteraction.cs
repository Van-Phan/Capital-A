using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseInteraction : MonoBehaviour
{
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //if we left click
        if (Input.GetMouseButtonDown(0))
        {
            //cast a ray to mouse position
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            //if we hit and object with left click within 100 distance
            if(Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);
            }
        }
    }
}
