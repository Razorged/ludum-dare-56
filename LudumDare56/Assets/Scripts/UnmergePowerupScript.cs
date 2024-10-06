using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnmergePowerupScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !collision.isTrigger)
        {
            collision.gameObject.GetComponent<PowerupScript>().EquipUnMergeGun();
            DestroyPowerup();
        }


    }
    private void DestroyPowerup()
    {
        Destroy(gameObject);
    }
}
