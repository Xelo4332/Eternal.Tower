using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyChecker : MonoBehaviour
{
    EnemyHealth[] enemies;
    private Health _health;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindObjectsOfType<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkEnemies())
        {
            SceneManager.LoadScene("MainM");
        }
    }

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
