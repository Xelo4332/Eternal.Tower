using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
   [SerializeField]
    private LayerMask platformslayermask ;
   
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2d;

   



    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0, 0)* Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
        if (IsGrounded() && Input.GetKeyDown(KeyCode.W)) 
        {
            
            float jumpforce = 15f;
            rb.velocity = Vector2.up * jumpforce; 

        }
    }private bool IsGrounded()
    {
        RaycastHit2D raycasthit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down,  .1f, platformslayermask);
        Debug.Log(raycasthit2d.collider);
        return raycasthit2d.collider != null;
    }
}
