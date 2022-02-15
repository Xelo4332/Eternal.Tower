using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DeathBox : MonoBehaviour
{
    private Health playerHealth;
    [SerializeField] private int damage;
    

    private void Start()
    {
        playerHealth = FindObjectOfType<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {

            playerHealth.TakeDamage(damage);

        }
    }
}
