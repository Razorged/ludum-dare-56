using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CritterBehaviour : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] deathSounds;
    public Animator animator;
    private LogicScript logicScript;
    public GameObject deathParticle;
    public GameObject player;
    public Rigidbody2D rb;
    public float randomMax;
    public float randomMin;
    public int runForce;
    private bool isRunning = false;
    public float movementTimerMax;
    private float movementTimer;
    

    // Start is called before the first frame update
    void Start()
    {

        logicScript = GameObject.Find("Logic Manager").GetComponent<LogicScript>();
        movementTimer = UnityEngine.Random.Range(0f, movementTimerMax);
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
            Vector3 direction = gameObject.transform.position - player.transform.position;
            float distance = direction.magnitude;
            float repellingForce = runForce / distance;
            direction = direction.normalized;
            rb.AddForce(direction * repellingForce * Time.deltaTime);
            isRunning = true;
            animator.SetBool("IsRunning", true);
        }
        
        if(collision.gameObject.tag == "Obstacle")
        {
            Vector3 direction = gameObject.transform.position - collision.gameObject.transform.position;
            float distance = direction.magnitude;
            float repellingForce = runForce / distance;
            direction = direction.normalized;
            rb.AddForce(direction * repellingForce * Time.deltaTime);
            isRunning = true;
            animator.SetBool("IsRunning", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isRunning = false;
        animator.SetBool("IsRunning", false);
    }

    private void RandomMovement()
    {
        if (!isRunning && movementTimer >= movementTimerMax)
        {
            Vector3 randomDirection = new Vector3(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f), 0);
            randomDirection = randomDirection.normalized;
            float force = UnityEngine.Random.Range(randomMin, randomMax);
            rb.AddForce(randomDirection * force);
            movementTimer = 0;
        }
    }

    public void KillCritter()
    {
        GameObject textObject = Instantiate(deathParticle, gameObject.transform.position, Quaternion.identity);
        deathParticle.GetComponent<ParticleSystem>().Play();
        logicScript.SubtractCritter();
        Destroy(gameObject);
    }

    private void PlayDeathSound()
    {
        System.Random r = new System.Random();
        int rInt = r.Next(deathSounds.Length);
        audioSource.clip = deathSounds[rInt];
        audioSource.Play();
    }

}
