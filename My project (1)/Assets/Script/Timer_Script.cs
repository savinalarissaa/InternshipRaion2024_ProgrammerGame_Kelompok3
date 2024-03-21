using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer_Script : MonoBehaviour
{
    public float currentTime;
    [SerializeField] private float startingTime = 0;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        if (currentTime <= 0)
        {
            TimedEvent.Invoke();
        }
    }

    public UnityEvent TimedEvent;
}
