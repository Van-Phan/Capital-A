using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject player;
    private float xVel;
    private float zVel;
    // Start is called before the first frame update
    void Start()
    {
        xVel = 0;
        zVel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        xVel = player.transform.position.x - rb.position.x;
        zVel = player.transform.position.z - rb.position.z;

        if(xVel > 2)
        {
            xVel = 2;
        }

        if(zVel > 2)
        {
            zVel = 2;
        }

        rb.velocity = new Vector3(xVel, 0, zVel);

        float rotation = Mathf.Atan2(xVel, zVel) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, rotation, 0);
    }
}
