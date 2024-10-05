using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CritterBallScript : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public GameObject textPrefab;
    public TextMeshPro textMeshPro;

    public int runForce;
    public int rollForce;
    public int count = 2;
    private Vector3 textOffset = new Vector3(0, 3f, 0);
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

    public void Initialize()
    {
        Debug.Log(gameObject.name);
        GameObject textObject = Instantiate(textPrefab, gameObject.transform.position + textOffset, Quaternion.identity);
        textMeshPro = textObject.GetComponent<TextMeshPro>();
        textObject.GetComponent<FollowCritterBallScript>().CritterBall = gameObject;
        UpdateCount();
    }

    public void UpdateCount()
    {
        count = gameObject.transform.childCount + 1;
        textMeshPro.text = count.ToString();
    }
}
