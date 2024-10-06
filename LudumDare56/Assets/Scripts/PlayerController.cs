using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject radius;
    public Rigidbody2D rb;
    public float moveSpeed;
    private Vector3 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject r = Instantiate(radius, gameObject.transform.position, Quaternion.identity);
        r.GetComponent<CircleRenderer>().radius = gameObject.GetComponent<CircleCollider2D>().radius * Math.Max(transform.localScale.x, transform.localScale.y);
        r.transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update()
    {
        direction = CalculateDirection();
        
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.transform.position + direction * moveSpeed);
    }

    //public void Move()
    //{
    //    float h = Input.GetAxis("Horizontal");
    //    float v = Input.GetAxis("Vertical");

    //    Vector3 tempVect = new Vector3(h, v, 0);
    //    tempVect = tempVect.normalized * moveSpeed * Time.deltaTime;
    //    rb.MovePosition(rb.transform.position + tempVect);
    //}

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
