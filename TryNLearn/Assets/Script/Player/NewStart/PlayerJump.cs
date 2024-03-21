using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce;

    private Rigidbody2D rB; //reference to the Rigidbody2D
    private Animator anim;

    private bool isJumping = false;
    private bool grounded;

    // Awake is called after all objects are initiallized. Called in a random order.
    private void Awake()
    {
        rB = GetComponent<Rigidbody2D>(); // Will look for the component on this GameObject(What the script is attached to) of type rigidbody.
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Jump(); 
        Animation();
    }

    //Better for handling update, can be called multiple times per update
    private void FixedUpdate()
    {
        //Move
        Movement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    //=====================================================================================================================

    private void Animation()
    {
        anim.SetBool("Grounded", grounded);// animation for checking whether the character is touching object tagged "Ground"
    }

    private void Movement()
    {
        if (isJumping)
        {
            rB.AddForce(new Vector2(0f, jumpForce)); // (x,y) with the jumpforce being added in the project
        }
        isJumping = false;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            isJumping = true;
            //anim.SetTrigger("Jump");
            grounded = false;

        }
    }
}
