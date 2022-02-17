using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyChecker : MonoBehaviour
{
    //Skappar array och health variable 
    EnemyHealth[] enemies;
    private Health _health;
    void Start()
    {
        enemies = GameObject.FindObjectsOfType<EnemyHealth>();
    }

    //Om alla enemies lika med deadm då kommer loada andra scene Deni
    void Update()
    {
        if (checkEnemies())
        {
            SceneManager.LoadScene("CaveFight");
        }
    }

    //Kollar om alla enemis är lika med dead Deni
    bool checkEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].dead == false)
            {
                return false;
            }
        }
        return true;
    }

   
}
