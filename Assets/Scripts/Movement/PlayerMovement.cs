using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Adds rigidbody2D 
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private float _moveSpeed;
   [SerializeField] private float _jumpForce;
   private Animator anim;
   private SpriteRenderer _spriteRenderer;
   [SerializeField] private AudioClip jumpSound;



    private bool _isGround;
   
   private Rigidbody2D _rigidbody;

   private void Start()
   {
       _rigidbody = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
       _spriteRenderer = GetComponent<SpriteRenderer>();

   }


   public void Move(float direction)
   {
        _rigidbody.velocity = new Vector2(direction * _moveSpeed, _rigidbody.velocity.y);


        if (direction != 0) anim.SetBool("run", true);
        else anim.SetBool("run", false);
   }
    
   public void Jump()
   {
       if (_isGround)
       {
           _rigidbody.velocity = Vector2.up * _jumpForce;
       }
        SoundManager.instance.PlaySound(jumpSound);

    }

       private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
        }
    }

     private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = false;
        }
    }
   
}
