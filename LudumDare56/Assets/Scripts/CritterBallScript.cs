using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterBallScript : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public int runForce;
    public int rollForce;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        rb.constraints = RigidbodyConstraints2D.None;
    }
    private void OnDisable()
    {
        gameObject.transform.rotation = Quaternion.identity;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
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
            rb.AddTorque(-direction.x * rollForce * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Vector3 direction = gameObject.transform.position - player.transform.position;
            float distance = direction.magnitude;
            float repellingForce = runForce / distance;
            rb.AddTorque(-direction.x * repellingForce * rollForce);
        }
    }
}
