using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    //This Settings for Damage, ColliderDistance, Range, coldwon timer with help of mathf.Ifinity and Layer for player to TakeDamage -Deni
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float coldownTimer = Mathf.Infinity;

    private Animator anim;
    //We create a variabel för our Health
    private Health playerHealth;

    private EnemyPatrolling enemyPatrol;

    //Get componenet  Animator and EnemyPatrolling Deni
    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrolling>();
    }

    //Plussar ihop ColdownTimer med deltaima -Martin
    private void Update()
    {
        coldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            // Att fiende f�rst�r n�r ska den sl� v�ran karakt�r -Martin
            if (coldownTimer >= attackCooldown)
            {
                coldownTimer = 0;
                anim.SetTrigger("MeleeAttack");

            }
        }
        
        //Om Enemy Patrol är lika med Null då aktiveras PlayerInSight methoden -Martin
        if(enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }

    }

    //Enemy har en Boxcollider där om Player kommer in denna box collider de kommer våran player börja få damage -Deni
    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }

    //Draws a gizmo to show where's Enemy Collider hitting point -Julian
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    //Method för player damage
    private void DamagePlayer()
    {

        
        if (PlayerInSight())
        {
            print("Hej");
            playerHealth.TakeDamage(damage);
        }

    }

}

