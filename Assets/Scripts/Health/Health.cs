using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Denna script är exact samma som Enemyhealth men skillnaden är att det är för player
//Men skillanden är att det finns Parry och andra små detaljer
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
    //Om parry = falkst då kommer player ta damage Deni
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

    //Bytter ut färger på player till rött i några sekunder Martin
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
