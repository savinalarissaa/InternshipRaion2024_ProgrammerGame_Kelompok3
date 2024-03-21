using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretArrow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Arrow hit");
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Hit Ground");
            Destroy(gameObject);
        }
    }
}
