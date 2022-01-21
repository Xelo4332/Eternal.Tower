using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
    //Hela Koden skrev Kacper
    
    //Skapar en field där man kan lägga in Left och right
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    //Field för att lägga in enemy så unity förstår vem ska röra sig
    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    //Alla de är för movement. Att enemy skulle kunna vända sig
    [Header("Movment Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    //Field för hur mycket kommer vara idle som kan ändras
    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    //Field för att kunna lägga in enemy animator controler så att enemy har animator har tillgång till enemy animations
    [Header("Enemy Animator")]
    [SerializeField]private Animator anim;


    //Att enemy facar rätt direction när spelet startas
    private void Awake()
    {
        initScale = enemy.localScale;
    }
    
    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }
    //Denna script är för om enemy kommer till en av edge posions som är x då kommer enemy byta holl Kacper
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
   
    //Om det händer method DirectionChange då kommer moving animation bli false och idleTimer börja Kacper
    private void DirectionChange()
    {
        anim.SetBool("moving", false);

        idleTimer += Time.deltaTime;
        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;


    }

   //Den här script är för att enemy skulle kunna röra sig och animations trigger kommer vara true.
    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("moving", true);

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }
}
