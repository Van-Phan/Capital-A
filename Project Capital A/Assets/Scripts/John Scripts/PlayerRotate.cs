using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotates the player when left arrow key is clicked
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player.transform.Rotate(new Vector3(30,0,0));
        }
    }
}
