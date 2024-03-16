using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fire_Attack : MonoBehaviour
{
    [SerializeField] private float attackCD;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    private Animator anim;
    private Fire_Movement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    private Fire_Movement fireMovement;
    private int playerSelect;

    private bool isFire;
    public enum MagicState
    {
        Fire,
        Water,
        Earth,
        Air
    }
    private MagicState state;
    private void Awake()
    {
        fireMovement = GetComponent<Fire_Movement>();
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<Fire_Movement>();
        firePoint = transform.GetChild(0).GetComponent<Transform>();
        playerSelect = PlayerManager.Instance.playerSelect;
    }
    private void Start()
    {
        switch (playerSelect)
        {
            case 0: state = MagicState.Fire; break;

        }
    }

    private void Update()
    {
        if(state == MagicState.Air)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                dash();
            }
        }
        if(Input.GetKeyDown(KeyCode.J) && cooldownTimer > attackCD && playerMovement.canAttack())
        {
            Debug.Log("klik");
            anim.SetTrigger("Attack");
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        
        Debug.Log(firePoint.position);
        
        cooldownTimer = 0;

        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection((fireMovement.facingRight) ? 1 : -1) ;
    }
    private void dash()
    {
        //dashing
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
