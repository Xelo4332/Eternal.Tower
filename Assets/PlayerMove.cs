using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
   
    public LayerMask platformslayermask ;
    public LayerMask enemyLayers;

   [SerializeField]
    private float speed = 5f;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2d;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 1;
    private float timer;
    private bool parry;
    [SerializeField] private GameObject parryBox;
    private float parryWindow = 0.5f;
   


    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        parryBox.SetActive(false);
        
    }


    void Update()
    {
        
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
            transform.position += new Vector3(speed, 0, 0)* Time.deltaTime;// These "If" codes make so that you move the diraction u press the button of-KK
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
        if (IsGrounded() && Input.GetKey(KeyCode.W)) // This code adds force upwards to the player making it jump -KK
        {
            
            float jumpforce = 15f;
            rb.velocity = Vector2.up * jumpforce; 

        }
        if (Input.GetKey(KeyCode.Space)& timer>1f)// press space to attack-KK
        {
            Attack();
            timer = 0;
        }
        if (Input.GetKey(KeyCode.P)&& !parry)// if you press the p key the this kode activates a emptybox that funcions as the parry box...-KK
        {
            parryBox.SetActive(true);
                parry= true;
            Invoke("ParryStop", parryWindow);
        }
    }
    void ParryStop()// stops the parry window-KK
    {
        parryBox.SetActive(false);
        parry = false;
    }
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); // Looks if the enemy is in the empty circle and gives it damage-KK

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
       
    }


private bool IsGrounded() // this code makes a boxcast thats checks if the player is touching the ground so that u can only jump on the ground-KK
    {
       
       RaycastHit2D raycasthit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down,  .1f, platformslayermask);
        Debug.Log(raycasthit2d.collider);
        return raycasthit2d.collider != null;
    }
    private void OnDrawGizmosSelected()// shows the empty circle that is the attack range-KK
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
