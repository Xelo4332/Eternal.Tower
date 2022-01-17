using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int playerMaxHealth = 3;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = playerMaxHealth;  
    }
    public void TakeDamage(int damage)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
