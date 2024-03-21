using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBallScript : MonoBehaviour
{
    private CircleCollider2D circleCollider;

    void Start() 
    { 
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (transform.position.x < 91)
        {
            circleCollider.isTrigger = false;
        }
    }
}
