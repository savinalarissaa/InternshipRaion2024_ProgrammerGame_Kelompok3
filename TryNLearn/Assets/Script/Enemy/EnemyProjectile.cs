using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    private bool hit;

    private Animator anim;
    private BoxCollider2D coll;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }
    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime ;
        transform.Translate(movementSpeed,0,0); 
        if(lifetime > resetTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        base.OnTriggerEnter2D(collision); // Executes logic from the parent script first
        coll.enabled = true;
        
        if(anim  != null)
        {
            anim.SetTrigger("Explode");//When the object is fireball, explode
        }
        else 
            gameObject.SetActive(false);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);//disables object when hitting a collider
    }

}
