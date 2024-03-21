using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ground : MonoBehaviour
{
    [SerializeField]private float moveDistance;
    [SerializeField]private float speed;
    [SerializeField] private float damage;

    private float leftEdge;
    private float rightEdge;
    private bool movingLeft;

    private void Awake()
    {
        leftEdge = transform.position.x - moveDistance;
        rightEdge = transform.position.x + moveDistance;

    }

    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingLeft = false;
        }
        else
        {

            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingLeft = true;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        
        }
    }



}
