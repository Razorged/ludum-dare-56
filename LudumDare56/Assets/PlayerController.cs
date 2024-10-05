using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = CalculateDirection();
        rb.MovePosition(rb.transform.position + direction*speed*Time.deltaTime);
    }

    public void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.transform.position + tempVect);
    }

    public Vector3 CalculateDirection()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;

        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;

        }

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.up;

        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.down;

        }
        return direction.normalized;
    }
}
