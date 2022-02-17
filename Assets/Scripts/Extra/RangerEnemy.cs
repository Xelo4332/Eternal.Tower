using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Sadly we didn't had enough time and knowledge to complete this script
But we will use this script in future games
There will be sequel of this game if we will be together again in program veckors nästa år
public class RangerEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Ranged Parameters")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] slimeBalls;




    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [SerializeField] private LayerMask playerLayer;
    private float coldownTimer = Mathf.Infinity;

    private Animator anim;
    //We create a variabel för our Health
    private Health playerHealth;
    private EnemyPatrolling enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrolling>();
    }

    private void Update()
    {
        coldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            // Att fiende f?rst?r n?r ska den sl? v?ran karakt?r Martin
            if (coldownTimer >= attackCooldown)
            {
                coldownTimer = 0;
                anim.SetTrigger("MeleeAttac");

            }
        }

        //Om Enemy Patrol är lika med Null då aktiveras PlayerInSight methoden Martin
        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }

    }

    private void RangedAttack()
    {
        attackCooldown = 0;
        slimeBalls[0].transform.position = firepoint.position;
        slimeBalls[0].GetComponent<EnemyProjectile>().ActivateProjectile;


    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);



        return hit.collider != null;
    }

    //Draws a gizmo to show where's Enemy Collider hitting point Julian
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

}
*/ 