using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private GameObject ObjectTouching;
    private bool PlateTriggered;

    [SerializeField] GameObject Trapdoor;

    private void Start()
    {
        PlateTriggered = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Ground" || collision.gameObject.name == "Player") 
            && (PlateTriggered == false))
        {
            ObjectTouching = collision.gameObject;
            Trapdoor.SetActive(false);
            PlateTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == ObjectTouching)
        {
            Trapdoor.SetActive(true);
            PlateTriggered = false;
        }
    }
}
