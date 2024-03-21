using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpItem : MonoBehaviour
{
    public GameObject Gate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //var keyCount = Gate.GetComponent<KeyCount>();
            //keyCount.addCount(1);
            Debug.Log("KeyEventStarted");
            CountKeys.Invoke();
            Destroy(gameObject);
        }
    }

    public UnityEvent CountKeys;
}
