using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Kacper
public class Health : MonoBehaviour
{

    public event System.Action PlayerIsDead;
    [Header("Health")]

    [SerializeField] private float startingHealth;

    public float currentHealth { get; private set; }
    private bool dead;

    [Header("iFrames")]
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
    //This method is for if player will take damage when hurt animation will play, if it's dead bool true then scene will load
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
                    PlayerIsDead?.Invoke();

                    DDOL[] ddols = FindObjectsOfType<DDOL>();
                    foreach (DDOL ddol in ddols)
                    {
                        Destroy(ddol.gameObject);
                    }


                    SceneManager.LoadScene("GameOver");
                }


            }
        }

    }

    //Takedamage method
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }
    //Iframes so if enemy will get damage then it will change sprite colour Deni
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }

}