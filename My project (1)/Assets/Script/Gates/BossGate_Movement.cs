using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGate_Movement : MonoBehaviour
{
    [SerializeField] private float gateSpeed;
    [SerializeField] private GameObject pointClosed;
    [SerializeField] private GameObject pointOpen;

    public bool gateClosed;

    private BoxCollider2D boxCollider;
    
    void Start()
    {
        gateClosed = false;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (gateClosed)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointClosed.transform.position, Time.deltaTime * gateSpeed);
        } else
        {
            transform.position = Vector2.MoveTowards(transform.position, pointOpen.transform.position, Time.deltaTime * gateSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gateClosed = true;
        }
    }

    public void OpenGates()
    {
        Debug.Log("Opening Gates");
        gateClosed = false;
        boxCollider.isTrigger = false;
    }

    public void CloseGates()
    {
        gateClosed = true;
    }
}
