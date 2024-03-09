using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    [Header("Attack Parameter")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player LAyer")]
    [SerializeField] private LayerMask playerLayer;
    private float cdTimer = Mathf.Infinity;

    private EnemyPatrol enemyPatrol;
    // Reference
    private Animator anim;
    private PlayerHealth Health;
}
