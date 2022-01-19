using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public bool isParry = false;

    public event System.Action<int> EnemyAttack;

    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private int _attackDamage = 1;


    [SerializeField] private BoxCollider2D _hitBox;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Coroutine _parryRoutine;
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

    private IEnumerator Parry()
    {
        isParry = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);

        yield return new WaitForSeconds(50);
        Physics2D.IgnoreLayerCollision(10, 11, false);
        isParry = false;



    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(Parry());
        }
    }

        private void OnDrawGizmosSelected()// shows the empty circle that is the attack range-KK
        {
            if (_attackPoint == null)
                return;
            Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
        }
    }
