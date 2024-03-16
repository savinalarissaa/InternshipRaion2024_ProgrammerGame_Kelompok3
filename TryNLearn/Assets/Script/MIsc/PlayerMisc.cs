using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMisc : MonoBehaviour
{
    public GameObject playerFire;
    public GameObject playerEarth;
    public GameObject playerWater;
    public GameObject playerWind;

    private void Awake()
    {
        playerFire = GetComponent<GameObject>();
    }
}
