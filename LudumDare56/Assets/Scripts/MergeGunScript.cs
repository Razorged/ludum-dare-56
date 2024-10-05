using System.Collections;
using UnityEngine;



public class MergeGunScript : PowerupScript
{
    public GameObject MergeBullet;
    public int cooldown = 2;
    public int bulletSpeed;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 shootDirection = mousePosition - gameObject.transform.position;
        shootDirection = shootDirection.normalized;
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        GameObject bullet = Instantiate(MergeBullet, transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));
        Physics2D.IgnoreCollision(bullet.GetComponent<CapsuleCollider2D>(), gameObject.GetComponent<BoxCollider2D>(), true);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = shootDirection * bulletSpeed; 

        Destroy(bullet, 5f);
    }

}
