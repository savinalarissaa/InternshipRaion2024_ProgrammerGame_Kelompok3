using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Skill : MonoBehaviour
{
    [Header("Attack Parameter")]
    [SerializeField] private float range;
    [SerializeField] private int damage;
    [SerializeField] private float attackCD;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject laserPrefab;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Enemy Layer")]
    [SerializeField] private LayerMask enemyLayer;

    [Header("Collider")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    private Animator anim;
    private NewBehaviourScript playerMovement;
    private PlayerHealth enemyHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<NewBehaviourScript>();
        firePoint = transform.GetChild(0).GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && cooldownTimer > attackCD && playerMovement.canAttack()) { 
            cooldownTimer = 0;
        Debug.Log("Attack K");
        Attack();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        gameObject.SetActive(true);
        GameObject laser = Instantiate(laserPrefab, firePoint.position, Quaternion.identity); 
        anim.SetTrigger("AttackLaser");
        DamageEnemy();
    }

    private bool EnemyInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, enemyLayer);
        if (hit.collider != null)
        {
            enemyHealth = hit.transform.GetComponent<PlayerHealth>();
        }
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamageEnemy()
    {
        if (EnemyInSight())
            enemyHealth.TakeDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
