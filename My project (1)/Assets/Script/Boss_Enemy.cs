using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Enemy : MonoBehaviour
{
    [SerializeField] private GameObject minionPrefab;
    [SerializeField] private GameObject minibossPrefab;
    [SerializeField] private Transform minibossPosition;
    [SerializeField] private Transform secondStagePosition;
    //private GameObject gateScript;
    private Rigidbody2D rb;
    private BossGate_Movement gateScript;
    
    [SerializeField] private float MaxEnemyHealth;
    [SerializeField] private float CurrentEnemyHealth;
    [SerializeField] private int MinionAmount;
    private float MinionsSpawnDelay = 1;
    private float lastMinionSpawnTime;
    private int MinionsSpawned;
    public int currentStage;
    public int MinionsDied;
    public bool minibossActive;

    private Vector3 stage2Position;
    private Vector3 initialPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gateScript = GetComponent<BossGate_Movement>();
        CurrentEnemyHealth = MaxEnemyHealth;
        MinionsSpawned = 0;
        currentStage = 1;
        MinionsDied = 0;
        minibossActive = false;
        initialPosition = gameObject.transform.position;
    }

    private void Update()
    { 
        if (CurrentEnemyHealth < 0) 
        {
            CurrentEnemyHealth = 0;
        }

        if (CurrentEnemyHealth == 0)
        {
            EnemyDies();
        }

        if (currentStage == 1)
        {
            float timeSinceLastMinion = Time.time - lastMinionSpawnTime;
            if (timeSinceLastMinion >= MinionsSpawnDelay && (MinionsSpawned < MinionAmount))
            {
                SpawnMinions();
                lastMinionSpawnTime = Time.time;
            }

            if (MinionsDied == MinionAmount)
            {
                currentStage += 1;
            }
        } 
        else if (currentStage == 2)
        {
            if (minibossActive == false)
            {

                SpawnMiniBoss();
            }
        } else if (currentStage == 3)
        {
            Debug.Log("stage 3");
            gameObject.transform.position = initialPosition;
        }
    }

    private void SpawnMinions()
    {
        Instantiate(minionPrefab, transform.position, Quaternion.identity);
        MinionsSpawned += 1;
        Debug.Log(MinionsSpawned);
    }

    private void SpawnMiniBoss()
    {
        stage2Position = secondStagePosition.transform.position;
        gameObject.transform.position = stage2Position;
        //gameObject.transform.position = new Vector3(secondStagePosition.transform.position.x, secondStagePosition.transform.position.y);
        Instantiate(minibossPrefab, minibossPosition.transform.position, Quaternion.identity);
        minibossActive = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            TakenDamage(10);
        }
    }

    public void TakenDamage(float amount)
    {
        CurrentEnemyHealth -= amount;
    }

    private void EnemyDies()
    {
        gateScript.OpenGates();
        Destroy(gameObject);
    }
}