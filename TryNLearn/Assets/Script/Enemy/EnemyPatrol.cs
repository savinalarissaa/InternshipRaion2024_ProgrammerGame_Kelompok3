using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;

    [Header("Idle")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    private Vector3 initialScale;
    private Boolean movingRight;

    [Header("Animation")]
    [SerializeField]private Animator anim;

    private void Awake()
    {
        initialScale = enemy.localScale;
    }

    private void OnDisable()
    {
        anim.SetBool("Move", false);
    }

    private void Update()
    {
        if(movingRight)
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();
                
        }
        else
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                DirectionChange();
        }
    }
    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("Move", true);

        //facing
        enemy.localScale = new Vector3(Mathf.Abs(initialScale.x) * _direction, 
            initialScale.y, initialScale.z);
        //move
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, 
            enemy.position.y, enemy.position.z);
    }

    private void DirectionChange()
    {
        anim.SetBool("Move", false);
        idleTimer += Time.deltaTime;
        if (idleTimer > idleDuration)
        {
            movingRight = !movingRight;
        }    
    }

}
