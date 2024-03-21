using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class BossMinion_Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Transform player;
    private Boss_Enemy boss;
    private Rigidbody2D rb;

    private float distance;

    private void Awake()
    {
        player = FindObjectOfType<Player_Movement>().transform;
        boss = FindObjectOfType<Boss_Enemy>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player"){ 
            Debug.Log("Minion Touched");
            Destroy(gameObject);
            boss.MinionsDied += 1;
            Debug.Log(boss.MinionsDied);
        }
    }
}
