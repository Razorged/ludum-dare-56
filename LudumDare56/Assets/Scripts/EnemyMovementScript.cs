using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public List<Vector2> coordinates;
    public float speed;
    private Vector2 target;
    private int targetIndex = 0;
    private int maxIndex;
    // Start is called before the first frame update
    void Start()
    {
        if(coordinates.Count == 0)
        {
            this.enabled = false;
        }
        else
        {
            maxIndex = coordinates.Count - 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if(target == null)
        {
            target = coordinates[targetIndex];
        }

        if(transform.position == new Vector3(target.x, target.y, 0))
        {
            if(targetIndex >= maxIndex)
            {
                targetIndex = 0;
            }
            else
            {
                targetIndex++;
            }
            target = coordinates[targetIndex];
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

    }

}
