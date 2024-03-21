using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder_Movement : MonoBehaviour
{
    public float moveSpeed;

    private float vertical;
    private bool OnLadder;
    private bool IsClimbing;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        OnLadder = false;
    }

    private void Update()
    {
        vertical = Input.GetAxis("Vertical"); //on a scale of -1 (down) to 1 (up)

        if (OnLadder && Mathf.Abs(vertical) > 0f) 
        {
            IsClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (IsClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * moveSpeed);
        }
        else
        {
            rb.gravityScale = 8f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            OnLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            OnLadder = false;
            IsClimbing = false;
        }
    }
}
