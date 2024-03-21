using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed;
    public bool facingRight = true;

    private Rigidbody2D rB; //reference to the Rigidbody2D
    private Animator anim;

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
    }

    private void Movement()
    {
        rB.velocity = new Vector2(moveDirection * moveSpeed, rB.velocity.y);
    }

    private void ProcessInput()
    {
        moveDirection = Input.GetAxisRaw("Horizontal"); //scale of (-1) to 1
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);

    }

    public bool canAttack()
    {
        return moveDirection == 0;
    }
}
