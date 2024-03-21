using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    [HideInInspector] public bool swimming;
    [HideInInspector] public Vector2 swimDir;

    private float speed = 30;

    private Rigidbody2D rb;
    private NewBehaviourScript playerMovement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<NewBehaviourScript>();
    }

    private void Update()
    {
        if (swimming == true)
            Swim();
    }

    private void Swim()
    {
        float dirX = 0f;
        float dirY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            dirY = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dirY = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            dirX = 1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            dirX = -1f;
        }

        Vector2 moveDir = new Vector2(dirX, dirY).normalized;

        if (moveDir.magnitude > 0f)
        {
            rb.gravityScale = 0.25f;
            swimDir = moveDir;
            rb.AddForce(swimDir * speed * Time.deltaTime, ForceMode2D.Impulse);
        }
        else
        {
            rb.gravityScale = 0.5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water") && !swimming)
        {
            swimming = true;
            playerMovement.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water") && swimming)
        {
            swimming = false;
            rb.gravityScale = 10f; // Reset gravity scale to default
            playerMovement.enabled = true;
        }
    }
}
