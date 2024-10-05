using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterBehaviour : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public int force = 100;
    private bool isRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Vector3 direction = gameObject.transform.position - player.transform.position;
            float distance = direction.magnitude;
            float repellingForce = force / distance;
            direction = direction.normalized;
            rb.AddForce(direction * repellingForce * Time.deltaTime);
        }
    }

}
