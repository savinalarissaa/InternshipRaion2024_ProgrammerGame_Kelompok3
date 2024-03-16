using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform_Movement : MonoBehaviour
{
    [SerializeField] private float Speed = 2f;

    [SerializeField] private GameObject[] Point;

    private int waypointIndex = 0;

    private void Update()
    {
        if (Vector2.Distance(Point[waypointIndex].transform.position, transform.position) < .1f)
        {
            waypointIndex++;

            if (waypointIndex >= Point.Length)
            {
                waypointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, Point[waypointIndex].transform.position, Time.deltaTime * Speed);
    }

}
