using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    

    [SerializeField] private float startingHealth;

    public float currentHealth { get; private set; }
    private bool dead;

    private Animator anim;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {


        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");


        }
        else
        {
           if (!dead)
           {
               anim.SetTrigger("die");
               if (GetComponent<EnemyPatrolling>() != null)
               {
                   GetComponent<EnemyPatrolling>().enabled = false;
               }
               
               if (GetComponent<EnemyMelee>() != null);
               {
                   GetComponent<EnemyMelee>().enabled = false;
               }
               dead = true;
           }
            

        }


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }
}
   
