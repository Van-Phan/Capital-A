using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseInteraction : MonoBehaviour
{
    Camera camera;
    public Interactable focus;
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
        //if we right click
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactible = hit.collider.GetComponent<Interactable>();
                if(interactible != null)
                {
                    Debug.Log("We hit an interactable object!");
                    SetFocus(interactible);
                }
            }
        }

        //if our player is moving the play doesn't focus on an interactible
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (input != Vector2.zero)
        {
            RemoveFocus();
        }
    }

    void SetFocus (Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
            {
                focus.OnDefocused();
            }
            focus = newFocus;
        }
        
        newFocus.OnFocused(transform);
    }
    void RemoveFocus ()
    {
        if(focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
    }
}
