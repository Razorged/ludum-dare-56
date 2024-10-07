using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "CritterBall" && gameObject.tag == "CritterBall")
        {
            if(collision.gameObject.GetInstanceID() > gameObject.GetInstanceID())
            {
                Merge(collision.gameObject);
            }
        }
        if(collision.gameObject.tag == "UnmergeBullet" && gameObject.tag == "CritterBall")
        {
            UnMerge();
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

    private void Merge(GameObject critterBall)
    {
        foreach(Transform child in critterBall.transform)
        {
            child.SetParent(null);
            PutCritterOnBall(gameObject, child.gameObject);
        }
        CircleCollider2D circleCollider2D = critterBall.GetComponent<CircleCollider2D>();
        circleCollider2D.enabled = false;
        critterBall.tag = "Critter";
        critterBall.GetComponent<CritterBallScript>().enabled = false;
        Destroy(critterBall.GetComponent<CritterBallScript>().textMeshPro.gameObject);
        PutCritterOnBall(gameObject, critterBall);
        
        UpdateCount();
    }

    private void PutCritterOnBall(GameObject parent, GameObject critter)
    {
        Vector3 resultVector = parent.transform.localPosition;
        critter.transform.localPosition = new Vector3(Random.Range(resultVector.x - 0.5f, resultVector.x + 0.5f), Random.Range(resultVector.y - 0.5f, resultVector.y + 0.5f), 0);
        float randomZRotation = Random.Range(0f, 360f);
        critter.transform.rotation = Quaternion.Euler(0, 0, randomZRotation);
        critter.transform.SetParent(parent.transform);
        critter.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        critter.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void UnMerge()
    {
        int childCount = gameObject.transform.childCount;

        for (int i = childCount - 1; i >= 0; i--)
        {
            Transform child = gameObject.transform.GetChild(i);
            child.SetParent(null);
            EnableParameter(child.gameObject);
        }
        //    foreach (Transform child in gameObject.transform)
        //{
        //    Debug.Log(child.gameObject.name);
        //    child.SetParent(null);
        //    EnableParameter(child.gameObject);
        //}
        CircleCollider2D circleCollider2D = gameObject.GetComponent<CircleCollider2D>();
        circleCollider2D.enabled = false;
        gameObject.tag = "Critter";
        gameObject.GetComponent<CritterBallScript>().enabled = false;
        Destroy(gameObject.GetComponent<CritterBallScript>().textMeshPro.gameObject);
        EnableParameter(gameObject);
    }

    private void EnableParameter(GameObject critter)
    {
        CritterMergeScript critterMergeScript = critter.GetComponent<CritterMergeScript>();
        CritterBehaviour critterBehaviour = critter.GetComponent<CritterBehaviour>();
        BoxCollider2D collider2D = critter.GetComponent<BoxCollider2D>();
        critterMergeScript.enabled = true;
        critterMergeScript.isGlued = false;
        critterBehaviour.enabled = true;
        collider2D.enabled = true;
        critter.transform.rotation = Quaternion.Euler(0, 0, 0);
        critter.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //critter.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void KillCritterBall()
    {
        int childCount = gameObject.transform.childCount;

        for (int i = childCount - 1; i >= 0; i--)
        {
            Transform child = gameObject.transform.GetChild(i);
            child.gameObject.GetComponent<CritterBehaviour>().KillCritter();
        }
        Destroy(gameObject.GetComponent<CritterBallScript>().textMeshPro.gameObject);
        gameObject.GetComponent<CritterBehaviour>().KillCritter();
    }

}
