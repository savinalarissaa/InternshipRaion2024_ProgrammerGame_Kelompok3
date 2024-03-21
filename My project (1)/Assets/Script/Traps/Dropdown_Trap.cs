using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dropdown_Trap : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            Debug.Log("Object Destroyed");
        } else if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            Debug.Log("Object Makes Contact");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Triggered");
            OnTrigger.Invoke();
        }
    }

    public UnityEvent OnTrigger;

    /*[SerializeField] private GameObject player;
    [SerializeField] private int DropSpeed;

    private Rigidbody2D rb;
    private Vector2 playerPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPosition = player.transform.position;
    }

    void Update()
    {
        if (transform.position.x == playerPosition.x)
        {
            Debug.Log("X");
        }

        if (transform.position.y > playerPosition.y)
        {
            Debug.Log("Y");
        }

        if ((transform.position.x == playerPosition.x) && (transform.position.y > playerPosition.y))
        {
            Debug.Log("UnderObject");
            rb.velocity = new Vector2(rb.velocity.x, (-1) * DropSpeed);
            //StartCoroutine(drop());
        }
    }*/

    //private IEnumerator drop()
    //{
    //animasi gerak gerik
    //yield return new WaitForSeconds(2);
    //rb.velocity = new Vector2(rb.velocity.x, (-1) * DropSpeed);
    //}
}
