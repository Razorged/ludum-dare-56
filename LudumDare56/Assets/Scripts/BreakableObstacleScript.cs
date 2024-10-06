using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BreakableObstacleScript : MonoBehaviour
{
    public GameObject deathParticle;
    public GameObject textPrefab;
    public TextMeshPro textMeshPro;
    public int count;
    public Vector3 textOffset;
    // Start is called before the first frame update
    void Start()
    {
        GameObject textObject = Instantiate(textPrefab, gameObject.transform.position + textOffset, Quaternion.identity);
        textObject.transform.SetParent(transform);
        textMeshPro = textObject.GetComponent<TextMeshPro>();
        textMeshPro.text = count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "CritterBall")
        {
            if(collision.gameObject.GetComponent<CritterBallScript>().count >= count)
            {
                Break();
            }
        }
    }

    private void Break()
    {
        GameObject textObject = Instantiate(deathParticle, gameObject.transform.position, Quaternion.identity);
        deathParticle.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
    }
}
