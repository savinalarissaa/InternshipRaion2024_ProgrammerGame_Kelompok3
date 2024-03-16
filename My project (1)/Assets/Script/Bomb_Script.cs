using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Script : MonoBehaviour
{
    [SerializeField] private float force;

    private Vector3 direction;
    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            direction = (transform.position - collision.transform.position).normalized;
            //direction.x = Mathf.Sign(direction.x);
            //direction.y = Mathf.Sign(direction.y);
            //direction *= -1;
            Debug.Log(direction);
            Explode();
            Destroy(gameObject);
        }
    }

    private void Explode()
    {
        Debug.Log("Bomb Exploded");
        rb.AddForce(direction * force, ForceMode2D.Impulse);
    }
}
