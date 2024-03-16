using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
    public List<GameObject> playerList;
    public GameObject playerFire;
    public GameObject playerEarth;
    public GameObject playerWater;
    public GameObject playerWind;

    private void Awake()
    {
        int playerSelect = PlayerManager.Instance.playerSelect;
        Instantiate(playerList[playerSelect]);
    }
}
