using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Field
    public GameObject player;
    private float xPos, yPos, zPos;

    // Start is called before the first frame update
    void Start()
    {
        xPos = player.transform.position.x;
        yPos = player.transform.position.y;
        zPos = player.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            zPos += 0.1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            zPos -= 0.1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            xPos -= 0.1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            xPos += 0.1f;
        }

        player.transform.position = new Vector3(xPos, yPos, zPos);
    }
}
