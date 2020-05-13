using UnityEngine;

public class Pickup : Interactable
{
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }
    public void PickUp()
    {
        Debug.Log("Picking up " + transform.name);
        Destroy(gameObject);
    }

}
