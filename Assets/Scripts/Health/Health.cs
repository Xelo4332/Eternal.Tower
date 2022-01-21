using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Denna script �r exact samma som Enemyhealth men skillnaden �r att det �r f�r player
public class Health : MonoBehaviour
{
    [Header ("Health")]

    [SerializeField] private float startingHealth;

    public float currentHealth { get; private set; }
    private bool dead;

    [Header ("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    CombatController controller;
    
    private void Awake()
    {
        controller = GetComponent<CombatController>();
        currentHealth = startingHealth;

        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {
        if (controller.isParry == false)
        {
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

            if (currentHealth > 0)
            {
                //hit animation
                StartCoroutine(Invunerability());

            }
            else 
            {
                if (!dead)
                {
                    SceneManager.LoadScene("GameOver");
                }


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
