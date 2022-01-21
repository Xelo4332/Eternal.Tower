using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Adds rigidbody2D 
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    //I de h�r fielder vi kan �ndra hastighet r�rlse p� player och hur l�ngt han hoppar
    //Field f�r 
   [SerializeField] private float _moveSpeed;
   [SerializeField] private float _jumpForce;
   private Animator anim;
   private SpriteRenderer _spriteRenderer;
   [SerializeField] private AudioClip jumpSound;



    private bool _isGround;
   
   private Rigidbody2D _rigidbody;

  //Tar up rigid body, animator, sprite renderer componenter s� vi kan anv�nda de i denna script Kacper;
   private void Start()
   {
       _rigidbody = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
       _spriteRenderer = GetComponent<SpriteRenderer>();

   }

    //Vi g�r att player skulle kunna r�ra sig med hj�lp av velociry Kacper
   public void Move(float direction)
   {
        _rigidbody.velocity = new Vector2(direction * _moveSpeed, _rigidbody.velocity.y);


        if (direction != 0) anim.SetBool("run", true);
        else anim.SetBool("run", false);
   }
    
   //We creating a jump method for our player and bool so we can check if player collide with ground Deni
   public void Jump()
   {
       if (_isGround)
       {
           _rigidbody.velocity = Vector2.up * _jumpForce;
       }
        SoundManager.instance.PlaySound(jumpSound);

    }

    //If player collide with ground, then jump method activates Deni
       private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
        }
    }

    //If not player does not collide with ground the he can't jump Deni
     private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = false;
        }
    }
   
}
