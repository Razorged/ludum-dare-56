using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterMergeScript : MonoBehaviour
{
    private bool isGlued = false;
    public GameObject critterBall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGlued)
        {
            if(collision.gameObject.tag == "Critter")
            {
                if (collision.gameObject.GetComponent<CritterMergeScript>().isGlued)
                {
                    if(collision.gameObject.GetInstanceID() > gameObject.GetInstanceID())
                    {
                        ParentMerge(collision.gameObject);
                    }
                }
                else
                {
                    ParentMerge(collision.gameObject);
                }
            }
        }
        else
        {
            if(collision.gameObject.tag == "MergeBullet")
            {
                GetGlued();
            }
        }
        if(collision.gameObject.tag == "CritterBall")
        {

        }
    }

    private void ParentMerge(GameObject otherCritter)
    { 
        PutCritterOnBall(gameObject, otherCritter);
        otherCritter.transform.SetParent(gameObject.transform);
        DisableParameters(otherCritter);
        otherCritter.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        otherCritter.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        EnableCritterBall();
        DisableParameters(gameObject);
    }

    private void ChildMerge(GameObject critterBall)
    {
        PutCritterOnBall(critterBall, gameObject);
        gameObject.transform.SetParent(critterBall.transform);
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        DisableParameters(gameObject);
    }

    private void GetGlued()
    {
        isGlued = true;
    }
    private void PutCritterOnBall(GameObject parent, GameObject critter)
    {
        Vector3 resultVector = parent.transform.position;
        critter.transform.position = new Vector3(Random.Range(resultVector.x -1.5f, resultVector.x + 1.5f), Random.Range(resultVector.y - 1.5f, resultVector.y + 1.5f), 0);
        float randomZRotation = Random.Range(0f, 360f);
        critter.transform.rotation = Quaternion.Euler(0, 0, randomZRotation);
    }
    private void DisableParameters(GameObject critter)
    {
        CritterMergeScript critterMergeScript = critter.GetComponent<CritterMergeScript>();
        CritterBehaviour critterBehaviour = critter.GetComponent<CritterBehaviour>();
        BoxCollider2D collider2D = critter.GetComponent<BoxCollider2D>();
        critterMergeScript.enabled = false;
        critterBehaviour.enabled = false;
        collider2D.enabled = false;
        
    }

    private void EnableCritterBall()
    {
        gameObject.tag = "CritterBall";
        CircleCollider2D circleCollider2D = gameObject.GetComponent<CircleCollider2D>();
        circleCollider2D.enabled = true;
        CritterBallScript critterBallScript = gameObject.GetComponent<CritterBallScript>();
        critterBallScript.enabled = true;
    }

}
