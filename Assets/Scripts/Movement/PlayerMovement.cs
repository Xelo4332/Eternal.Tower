using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Adds rigidbody2D 
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    //I de här fielder vi kan ändra hastighet rörlse på player och hur långt han hoppar
    //Field för 
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    private Animator anim;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _checkRadius;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _groundLayer;
    private bool isJump;
    private int jumpIteration;
    [SerializeField] private int jumpIterationCount;





    private bool _isGround;

    private Rigidbody2D _rigidbody;

    //Tar up rigid body, animator, sprite renderer componenter så vi kan använda de i denna script Kacper;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    //Vi gör att player skulle kunna röra sig med hjälp av velociry Kacper
    public void Move(float direction)
    {
        _rigidbody.velocity = new Vector2(direction * _moveSpeed, _rigidbody.velocity.y);


        if (direction != 0) anim.SetBool("run", true);
        else anim.SetBool("run", false);
    }

    //We creating a jump method for our player and bool so we can check if player collide with ground Deni
    private void Jump()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (_isGround)
            {
                isJump = true;
            }

        }
        else
        {
            isJump = false;
        }

        if (isJump)
        {
            if (jumpIteration++ < jumpIterationCount)
            {
                _rigidbody.AddForce(Vector2.up * _jumpForce / jumpIteration);

            }
        }
        else
        {
            jumpIteration = 0;
        }


    }

    //If player collide with ground, then jump method activates Deni
    private void CheckingGround()
    {
        _isGround = Physics2D.OverlapCircle(_groundChecker.position, _checkRadius, _groundLayer);
    }

    private void Update()
    {
        CheckingGround();
        Jump();
    }

    //Changing direction moveDriction if it's more then 1 or lower Deni
    public void Turn(float moveDirection)
    {
        Vector2 turnDirection = transform.localScale;

        if (moveDirection > 0)
        {
            turnDirection = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        if (moveDirection < 0)
        {
            turnDirection = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        transform.localScale = turnDirection;
    }

}
   
