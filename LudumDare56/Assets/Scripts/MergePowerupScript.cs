using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergePowerupScript : MonoBehaviour
{
    public bool primed = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !collision.isTrigger && primed == true)
        {
            collision.gameObject.GetComponent<PowerupScript>().EquipMergeGun();
            DestroyPowerup();
        }
    }

    private void DestroyPowerup()
    {
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !collision.isTrigger)
        {
            primed = true;
        }
    }


}
