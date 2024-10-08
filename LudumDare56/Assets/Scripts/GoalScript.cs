using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public LogicScript logicScript;
    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.Find("Logic Manager").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Critter")
        {
            logicScript.AddScore();
        }
        if(collision.gameObject.tag == "CritterBall")
        {
            logicScript.AddScore(collision.gameObject.GetComponent<CritterBallScript>().count);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Critter")
        {
            logicScript.SubtractScore();
        }
        if (collision.gameObject.tag == "CritterBall")
        {
            logicScript.SubtractScore(collision.gameObject.GetComponent<CritterBallScript>().count);
        }
    }
}
