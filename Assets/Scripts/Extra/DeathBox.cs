using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DeathBox : MonoBehaviour
{
    //Kacper
    private Health playerHealth;
    [SerializeField] private int damage;
    

    //Hittar componenten health
    private void Start()
    {
        playerHealth = FindObjectOfType<Health>();
    }
    //Om den taggar med player, då tar han damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {

            playerHealth.TakeDamage(damage);

        }
    }
}
