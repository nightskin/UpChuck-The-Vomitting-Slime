using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public GameObject barf;
    public float speed;
    public float jumpForce;

    GameObject atk_Btn;

    GameObject jump_Btn;

    public Vector2 sensitivity;
    public Joystick joystick;

    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        atk_Btn = GameObject.Find("B");
        jump_Btn = GameObject.Find("A");
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Move()
    {
        anim.SetInteger("spdX",(int)rb.velocity.x);

        if (joystick.Horizontal > sensitivity.x)
        {
            sprite.flipX = false;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            
        }
        else if (joystick.Horizontal < -sensitivity.x)
        {
            sprite.flipX = true;
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }
    
    void Update()
    {
        Move();
        Jump();
        Attack();
    }

    public void Attack()
    {
        anim.SetBool("atk", atk_Btn.GetComponent<CheckHold>().pressed);
        if(anim.GetBool("atk"))
        {
            if(joystick.Direction != Vector2.zero)
            {
                
            }
            else
            {
                
            }
        }
    }

    public void Jump()
    {
        if (jump_Btn.GetComponent<CheckHold>().pressed)
        {
            if (anim.GetBool("ground"))
            {
                anim.SetTrigger("jump");
                rb.velocity = Vector2.up * jumpForce;
            }
            jump_Btn.GetComponent<CheckHold>().pressed = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platforms")
        {
            anim.SetBool("ground", true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platforms")
        {
            anim.SetBool("ground", false);
        }
    }

}
