using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBoxScript : MonoBehaviour
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
        if (collision.gameObject.tag == "Critter")
        {
            collision.gameObject.GetComponent<CritterBehaviour>().KillCritter();
        }
    }
}
