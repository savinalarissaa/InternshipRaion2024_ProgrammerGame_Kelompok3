using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class Vase_Breaking : MonoBehaviour
{

    public GameObject DropItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            if (gameObject.tag != "Empty")
            {
                Instantiate(DropItem, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    
}
