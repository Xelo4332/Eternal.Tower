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
    public int attackDamage = 40;
    public Transform attackPos;
    private float timer;



    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
            transform.position += new Vector3(speed, 0, 0)* Time.deltaTime;// These "If" codes make so that you move the diraction u press the button of
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
        if (IsGrounded() && Input.GetKey(KeyCode.W)) // This code adds force upwards to the player making it jump
        {
            
            float jumpforce = 15f;
            rb.velocity = Vector2.up * jumpforce; 

        }
        if (Input.GetKey(KeyCode.Space)& timer>1f)// press space to attack
        {
            Attack();
            timer = 0;
        }
    }
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); // 

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
       
    }


private bool IsGrounded() // this code makes a boxcast thats checks if the player is touching the ground so that u can only jump on the ground
    {
       
       RaycastHit2D raycasthit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down,  .1f, platformslayermask);
        Debug.Log(raycasthit2d.collider);
        return raycasthit2d.collider != null;
    }
    private void OnDrawGizmosSelected()// shows the empty circle
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
