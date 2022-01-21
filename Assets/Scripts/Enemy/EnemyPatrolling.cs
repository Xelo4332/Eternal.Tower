using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
    //Hela Koden skrev Kacper
    
    //Skapar en field d�r man kan l�gga in Left och right
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    //Field f�r att l�gga in enemy s� unity f�rst�r vem ska r�ra sig
    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    //Alla de �r f�r movement. Att enemy skulle kunna v�nda sig
    [Header("Movment Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    //Field f�r hur mycket kommer vara idle som kan �ndras
    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    //Field f�r att kunna l�gga in enemy animator controler s� att enemy har animator har tillg�ng till enemy animations
    [Header("Enemy Animator")]
    [SerializeField]private Animator anim;


    //Att enemy facar r�tt direction n�r spelet startas
    private void Awake()
    {
        initScale = enemy.localScale;
    }
    
    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }
    //Denna script �r f�r om enemy kommer till en av edge posions som �r x d� kommer enemy byta holl Kacper
    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
                DirectionChange();
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
                DirectionChange();


        }
    }
   
    //Om det h�nder method DirectionChange d� kommer moving animation bli false och idleTimer b�rja Kacper
    private void DirectionChange()
    {
        anim.SetBool("moving", false);

        idleTimer += Time.deltaTime;
        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;


    }

   //Den h�r script �r f�r att enemy skulle kunna r�ra sig och animations trigger kommer vara true.
    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("moving", true);

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }
}
