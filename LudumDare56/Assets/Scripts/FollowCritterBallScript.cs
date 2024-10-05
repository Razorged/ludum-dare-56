using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCritterBallScript : MonoBehaviour
{
    public GameObject CritterBall;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CritterBall != null)
        {
            transform.position = CritterBall.gameObject.transform.position + offset;

        }
    }
}
