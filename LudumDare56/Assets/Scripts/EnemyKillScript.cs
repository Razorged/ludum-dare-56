using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyKillScript : MonoBehaviour
{
    public GameObject deathParticle;
    public GameObject textPrefab;
    public TextMeshPro textMeshPro;
    public LogicScript logicScript;
    public Vector3 textOffset;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.Find("Logic Manager").GetComponent<LogicScript>();
        GameObject a = Instantiate(textPrefab, gameObject.transform.position + textOffset, Quaternion.identity);
        a.transform.SetParent(transform);
        textMeshPro = a.GetComponent<TextMeshPro>();
        textMeshPro.text = count.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Critter")
        {
            collision.gameObject.GetComponent<CritterBehaviour>().KillCritter();
        }
        if (collision.gameObject.tag == "CritterBall")
        {
            if (collision.gameObject.GetComponent<CritterBallScript>().count >= count)
            {
                Die();
            }
            else
            {
                collision.gameObject.GetComponent<CritterBallScript>().KillCritterBall();
            }
            
        }
    }

    private void Die()
    {
        GameObject textObject = Instantiate(deathParticle, gameObject.transform.position, Quaternion.identity);
        deathParticle.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
    }


}
