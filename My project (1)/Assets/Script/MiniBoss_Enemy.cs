using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MiniBoss_Enemy : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    private Boss_Enemy boss;
    private Animator anim;
    [SerializeField] GameObject[] teleportPoint;

    [SerializeField] private int bulletForce;
    [SerializeField] private int shotsUntilTeleport;
    [SerializeField] private float shootDelay;
    [SerializeField] private float teleportingDelay;
    [SerializeField] private float currentHealth;
    [SerializeField] private float maximumHealth;


    private float lastShootTime;
    private int stage;
    private int shotsFired;
    private int teleportPointIndex;
    public bool isTeleporting;
    public bool isShooting;

    void Start()
    {
        stage = 1;
        shotsFired = 0;
        teleportPointIndex = 0;
        currentHealth = maximumHealth;
        boss = FindObjectOfType<Boss_Enemy>();
        anim = GetComponent<Animator>();
        isTeleporting = false;
        isShooting = false;
    }

    void Update()
    {
        //delay awal + activate platform

        if (currentHealth < 0)
        {
            currentHealth = 0;
        } 

        if (currentHealth == 0)
        {
            EnemyDies();
        }

        if (stage== 1 && !isTeleporting){ // tembakan horizontal

            float timeSinceLastShot = Time.time - lastShootTime;
            isShooting = true;
            anim.SetBool("isShooting", true);

            if (timeSinceLastShot >= shootDelay)
            {
                Shoot();
                lastShootTime = Time.time;
                shotsFired++;
            }

            if (shotsFired == shotsUntilTeleport)
            {
                stage++;
                Debug.Log("TEST");
                isShooting = false;
                anim.SetBool("isShooting", false);
            }

        } else if (stage == 2 && !isTeleporting) // teleport ke seberang ruangan
        {
            Debug.Log("test");
            StartCoroutine(Teleport());
            
        }
        //ulang sampai habis healthnya
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            TakeDamage(10);
            Debug.Log("hit player");
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
    }

    private void EnemyDies()
    {
        Destroy(gameObject);
        Debug.Log("destroyed");
        boss.minibossActive = false;
        boss.currentStage += 1;
    }

    private IEnumerator Teleport()
    {
        isTeleporting = true;
        Debug.Log("1");
        yield return new WaitForSeconds(teleportingDelay);
        teleportPointIndex += 1;
        if (teleportPointIndex >= 2) teleportPointIndex = 0;
        gameObject.transform.position = new Vector3(teleportPoint[teleportPointIndex].transform.position.x, teleportPoint[teleportPointIndex].transform.position.y);
        gameObject.transform.rotation = teleportPoint[teleportPointIndex].transform.rotation;
        Debug.Log("2");
        yield return new WaitForSeconds(teleportingDelay);
        Debug.Log("3");
        stage = 1;
        shotsFired = 0;
        isTeleporting = false;
    }
}
