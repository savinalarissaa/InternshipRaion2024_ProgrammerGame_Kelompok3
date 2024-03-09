using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private PlayerMovement playerMovement;

    [SerializeField] private float attackCD;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
    anim = GetComponent<Animator>();
    playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && cooldownTimer>attackCD && playerMovement.canAttack())
            Attack();
        

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
        cooldownTimer = 0;
    }
}
