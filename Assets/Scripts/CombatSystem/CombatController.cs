using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    //Kacper and Deni wrote the code
    public bool isParry = false;

    //Event for Enemy Attack
    public event System.Action<int> EnemyAttack;

    //Using layer to damage the player 
    //Settings for Attack point like Range and damage
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private int _attackDamage = 1;
   


    [SerializeField] private BoxCollider2D _hitBox;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Coroutine _parryRoutine;
    private Animator anim;

    //Gets Animator component so we can use animator
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    //If Enemy is in attack point and you will press shift then it will activate TakeDamage method Kacper
    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayer); //  Makes a empty circle and dameges all things with the layer "enemyLayer"-KK

        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyAttack?.Invoke(_attackDamage); //Send Event
            enemy.GetComponent<EnemyHealth>().TakeDamage(_attackDamage);

            print("hejd�");
        }

    }

    //Layer mask changes so you become invisble to attacks in some seconds Deni
    private IEnumerator Parry()
    {
        isParry = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        anim.SetTrigger("isParry");
        GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(1);
        Physics2D.IgnoreLayerCollision(10, 11, false);
        isParry = false;
        GetComponent<PlayerMovement>().enabled = true;
        yield return new WaitForSeconds(3);




    }

    //Input for parry Deni

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(Parry());
        }
    }
        
        //Will draw Attack point Gizmo and you will able to see it Kacper
        private void OnDrawGizmosSelected()// shows the empty circle that is the attack range-KK
        {
            if (_attackPoint == null)
                return;
            Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
        }
    }

