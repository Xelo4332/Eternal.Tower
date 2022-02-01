using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
//Deni Wrote the code
{

    //Field to write enemy starting health
    [SerializeField] private float startingHealth;

    //How much is current health and it's private set so only some scripts can acess it 

    //Denna variablar är för kunna kolla Hur mycket har player health under spelet och har bool död att kunna kolla om player eller enemy är död
    public float currentHealth { get; private set; }
    private bool dead;
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Animations")]
    private Animator anim;

    //Två audioclippar och Bevhiour så att kunna stänga alla componenets när spelet är slut
    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    [SerializeField] private AudioClip enemyHit;
    [SerializeField] private AudioClip enemyDeath;

    //Gets animator component and when the game start current health will get same number of health that you had it health
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    //If enemy will take damage then hurt aniamtion will activate and enemy will lose health. If health = 0 or dead then all components will be turned off
    public void TakeDamage(float _damage)
    {


        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            SoundManager.instance.PlaySound(enemyHit);

        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                foreach (Behaviour component in components)
                    component.enabled = false;

                SoundManager.instance.PlaySound(enemyDeath);

                dead = true;
            }


        }


    }

    //Test for damage taking, not important
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }

    private IEnumerator Invunerability()
    {

        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }

    }
}

