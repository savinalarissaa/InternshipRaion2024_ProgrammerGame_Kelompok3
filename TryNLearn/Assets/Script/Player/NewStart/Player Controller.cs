using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public CinemachineVirtualCamera virtualCamera;
    private Transform playerTransform;
    // Define enum for character types
    public enum CharacterType
    {
        Fire,
        Wind,
        Water,
        Earth
    }

    // Define enum for skills
    public enum Attack
    {
        None,
        BasicAttack,
        Skill,
        Projectile
    }


    public CharacterType currentCharacter;
    public Attack currentSkill;

    // Store references to scripts for each element
    private NewBehaviourScript playerMove;
    private PlayerJump playerJump;
    private PlayerSwim playerSwim;
    private Fire_Basic fireBasicAttack;
    private Fire_Skill fireSkill;
    private Water_Basic waterBasicAttack;
    private Water_Shield waterShield;
    private WaterMovement waterMovement;
    private Earth_Basic earthBasicAttack;
    private Earth_Skill earthSkill;
    private Wind_Basic windBasicAttack;
    private Wind_Dash windDash;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Ensure that the GameObject persists across scene changes
        }
        else
        {
            Destroy(gameObject); // If another instance of PlayerController exists, destroy this one
        }


        // Get references to player scripts
        playerJump = GetComponent<PlayerJump>();
        playerMove = GetComponent<NewBehaviourScript>();
        playerSwim = GetComponent<PlayerSwim>();
        fireBasicAttack = GetComponent<Fire_Basic>();
        fireSkill = GetComponent<Fire_Skill>();
        waterBasicAttack = GetComponent<Water_Basic>();
        waterShield = GetComponent<Water_Shield>();
        waterMovement = GetComponent<WaterMovement>();
        earthBasicAttack = GetComponent<Earth_Basic>();
        earthSkill = GetComponent<Earth_Skill>();
        windBasicAttack = GetComponent<Wind_Basic>();
        windDash = GetComponent<Wind_Dash>();
    }

    void Start()
    {
        // Disable all scripts first
        DisableAllScripts();
        SceneManager.sceneLoaded += OnSceneLoaded;
        /*
                // Example: Set default character and skill
                currentCharacter = CharacterType.Water;
                currentSkill = Attack.BasicAttack;*/
    }

    void Update()
    {
        // Check for input to change character or skill
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentCharacter = CharacterType.Fire;
            currentSkill = Attack.BasicAttack;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentCharacter = CharacterType.Water;
            currentSkill = Attack.BasicAttack;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentCharacter = CharacterType.Wind;
            currentSkill = Attack.BasicAttack;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentCharacter = CharacterType.Earth;
            currentSkill = Attack.BasicAttack;
        }
        // Perform actions based on current character and skill
        //PerformAction();
    }

    void PerformAction()
    {
        switch (currentCharacter)
        {
            case CharacterType.Fire:
                // Enable all Fire-related scripts
                fireBasicAttack.enabled = true;
                fireSkill.enabled = true;
                break;
            case CharacterType.Water:
                // Enable all Water-related scripts
                playerSwim.enabled = false;
                waterMovement.enabled = true;
                waterBasicAttack.enabled = true;
                waterShield.enabled = true;
                break;
            case CharacterType.Earth:
                // Enable all Fire-related scripts
                earthBasicAttack.enabled = true;
                earthSkill.enabled = true;
                break;
            case CharacterType.Wind:
                // Enable all Water-related scripts
                playerJump.enabled = false;
                playerMove.enabled = false;
                windBasicAttack.enabled = true;
                windDash.enabled = true;
                break;
        }
    }

    public void DisableAllScripts()
    {
        // Disable all scripts first
        fireBasicAttack.enabled = false;
        fireSkill.enabled = false;
        waterBasicAttack.enabled = false;
        waterShield.enabled = false;
        waterMovement.enabled = false;
        earthBasicAttack.enabled = false;
        earthSkill.enabled = false;
        windBasicAttack.enabled = false;
        windDash.enabled = false;
    }

    public void SetCurrentCharacter(CharacterType characterType)
    {
        currentCharacter = characterType;
        PerformAction(); // Update the character actions
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find the player's GameObject in the newly loaded scene
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerTransform = player.transform;
            // Set the follow target of the Cinemachine virtual camera to the player's transform
            virtualCamera.Follow = playerTransform;
        }
        else
        {
            Debug.LogWarning("Player not found in the scene!");
        }
    }
}