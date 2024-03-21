using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float shootDelay;
    public float bulletForce = 20f;

    private bool PlayerSpotted;
    private float lastShootTime;

    private void Start()
    {
        PlayerSpotted = false;
    }

    void Update()
    {
        if (PlayerSpotted)
        {
            float timeSinceLastShot = Time.time - lastShootTime;

            if (timeSinceLastShot >= shootDelay)
            {
                Shoot();
                lastShootTime = Time.time;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerSpotted = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerSpotted = false;
        }
    }

}
