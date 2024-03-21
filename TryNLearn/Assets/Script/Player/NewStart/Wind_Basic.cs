using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_Basic : MonoBehaviour
{
    [SerializeField] private float attackCD;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    private Animator anim;
    private NewBehaviourScript playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        playerMovement = GetComponent<NewBehaviourScript>();
        anim = GetComponent<Animator>();
        firePoint = transform.GetChild(0).GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && cooldownTimer > attackCD && playerMovement.canAttack())
        {

            Debug.Log("klik");
            anim.SetTrigger("Attack");
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        cooldownTimer = 0;
        Debug.Log(firePoint.position);
        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Wind_Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
