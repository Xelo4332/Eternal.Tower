using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DASH : MonoBehaviour { 
public float dashCooldown;
public bool canIDash = true;
public Vector2 savedVelocity;

 public    Rigidbody2D rb;

    void fixedUpdate()
    {
        if (dashCooldown > 0)
        {
            canIDash = false;
            dashCooldown -= Time.deltaTime;
           
        }
        if (dashCooldown <= 0)
        {
            canIDash = true;
            
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canIDash == true)
        {
            //saves velocity prior to dashing
            savedVelocity = rb.velocity;
            //this part is the actual dash itself rb.velocity = new Vector2(rb.velocity.x * 5f, rb.velocity.y);
            rb.velocity = new Vector2(rb.velocity.x * 5f, rb.velocity.y);
            dashCooldown = 2;
        }
    }
}