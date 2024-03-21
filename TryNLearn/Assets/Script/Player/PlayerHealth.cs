using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    private Animator anim;
    private bool dead;
    public float currentHealth {  get; private set; }

    [Header("iFrame")]
    [SerializeField]private float iFrameDuration;
    [SerializeField]private int numberOffFlashes;
    private SpriteRenderer spriteRenderer;

    [Header("GetComponents")]
    [SerializeField]private Behaviour[] components;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        if (currentHealth > 0) 
        {
            anim.SetTrigger("Hurt");
            StartCoroutine(Invulnerability());
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("Die");

                //Deactivate all attached components
                foreach (Behaviour component in components)
                    component.enabled = false;

                dead = true;   
            }
        }
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(3, 6, true);
        //invulberability duration
        for(int i = 0; i < numberOffFlashes; i++) { 
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds((iFrameDuration)/(numberOffFlashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds((iFrameDuration) / (numberOffFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(3, 6, false);
    }
    
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
