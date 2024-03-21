using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Shield : MonoBehaviour
{
    private bool isShielded;
    private PlayerHealth Health;
    [SerializeField] private GameObject shield;

    // Start is called before the first frame update
    void Start()
    {
        Health = GetComponent<PlayerHealth>();
        isShielded = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckShield();
    }

    void CheckShield()
    {
        if(Input.GetKeyDown(KeyCode.K) && !isShielded) { 
            shield.SetActive(true);
            isShielded=true;
            Invoke("NoShield", 10f);
        }
    }

    void NoShield()
    {
        shield.SetActive(false);
        isShielded=false;
    }
}
