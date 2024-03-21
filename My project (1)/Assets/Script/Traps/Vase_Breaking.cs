using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class Vase_Breaking : MonoBehaviour
{

    public GameObject DropItem;
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            if (gameObject.tag != "Empty")
            {
                GameObject key = Instantiate(DropItem, transform.position, Quaternion.identity);
                key.GetComponent<PickUpItem>().Gate = door;
            }
            Destroy(gameObject);
        }
    }

    
}
