using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterMergeScript : MonoBehaviour
{
    private bool isGlued = false;
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
                Merge();
            }
        }
    }

    private void Merge()
    {

    }

}
