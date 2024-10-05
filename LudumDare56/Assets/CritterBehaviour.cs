using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CritterBehaviour : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public int runForce;
    private bool isRunning = false;
    public float movementTimerMax = 3;
    private float movementTimer;

    // Start is called before the first frame update
    void Start()
    {
        movementTimer = UnityEngine.Random.Range(0f, 3f);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(movementTimer < movementTimerMax)
        {
            movementTimer = movementTimer + Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        RandomMovement();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Running");
            Vector3 direction = gameObject.transform.position - player.transform.position;
            float distance = direction.magnitude;
            float repellingForce = runForce / distance;
            direction = direction.normalized;
            rb.AddForce(direction * repellingForce * Time.deltaTime);
            isRunning = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isRunning = false;
    }

    private void RandomMovement()
    {
        if (!isRunning && movementTimer >= movementTimerMax)
        {
            Debug.Log("Random");
            Vector3 randomDirection = new Vector3(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f), 0);
            randomDirection = randomDirection.normalized;
            float force = UnityEngine.Random.Range(150f, 300f);
            rb.AddForce(randomDirection * force);
            movementTimer = 0;
        }
    }

}
