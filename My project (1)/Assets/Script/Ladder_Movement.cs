using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder_Movement : MonoBehaviour
{
    public float moveSpeed;
    private bool OnLadder;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        OnLadder = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            OnLadder = true;
        } else
        {
            OnLadder = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder" && OnLadder)
        {
            ClimbLadder();
        }
    }

    private void ClimbLadder()
    {
        rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
    }
}
