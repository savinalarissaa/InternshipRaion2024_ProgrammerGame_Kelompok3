using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporary_Blocks : MonoBehaviour
{
    [SerializeField] private float timeUntilDrop;
    [SerializeField] private float fallDelay;
    [SerializeField] private float destroyDelay;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(BlockFalling());
        }
    }

    private IEnumerator BlockFalling()
    {
        Debug.Log("TEST");
        yield return new WaitForSeconds(timeUntilDrop);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}
