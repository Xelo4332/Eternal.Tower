using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public event  System.Action<int> EnemyAttack;

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
           enemy.GetComponent<Health>().TakeDamage(_attackDamage);
        }
       
    }

    public void Parry()
    {
        if(_parryRoutine == null)
        {
            _parryRoutine = StartCoroutine(ParryRoutine());
        }

    }
    private IEnumerator ParryRoutine()
    {
        _hitBox.enabled = false;
        _spriteRenderer.enabled = false;

        yield return new WaitForSeconds(0.5f);

        _hitBox.enabled = true;
        _spriteRenderer.enabled = true;
        
        yield return new WaitForSeconds(0.5f);

        if(_parryRoutine != null)
        {
            _parryRoutine = null;
        }


        

    }
}
