using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tornado_Movement : MonoBehaviour
{

    [SerializeField] private float Speed;
    [SerializeField] private GameObject Target;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * Speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Tornado hit");
        }
    }
}