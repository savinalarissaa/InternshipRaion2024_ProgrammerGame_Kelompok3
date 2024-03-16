using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Movement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rB; //reference to the Rigidbody2D
    private Animator anim;

    private bool isJumping = false;
    public bool facingRight = true;
    private bool grounded;
    private float moveDirection;

    // Awake is called after all objects are initiallized. Called in a random order.
    private void Awake()
    {
        rB = GetComponent<Rigidbody2D>(); // Will look for the component on this GameObject(What the script is attached to) of type rigidbody.
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        ProcessInput(); //
        //Animate 
        Animation(); //switch character direction
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
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
        anim.SetBool("run", moveDirection != 0); // animation for running
        anim.SetBool("Grounded", grounded);// animation for checking whether the character is touching object tagged "Ground"
    }

    private void Movement()
    {
        rB.velocity = new Vector2(moveDirection * moveSpeed, rB.velocity.y);
        if (isJumping)
        {
            rB.AddForce(new Vector2(0f, jumpForce)); // (x,y) with the jumpforce being added in the project
        }
        isJumping = false;
    }

    private void ProcessInput()
    {
        moveDirection = Input.GetAxisRaw("Horizontal"); //scale of (-1) to 1
        Jump();
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);

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

    public bool canAttack()
    {
        return moveDirection == 0;
    }

}
