using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_tut : MonoBehaviour
{
    [Header("misc")]
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator anim;

    [Header("movement")]
    public float speed;
    public float jumpForce;
    public Vector3 target;
    public bool moving;
    public bool midair;

    [Header("controls")]
    public Vector2 moveSense;
    public Vector2 shootSense;
    public Joystick move_stick;
    public Joystick shootStick;

    [Header("shooting")]
    public GameObject vomit;
    public GameObject mouth;
    public float shootForce;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        mouth = transform.GetChild(0).gameObject;
    }

    void Move()
    {
        anim.SetInteger("spdX", (int)rb.velocity.x);
        if (move_stick.Horizontal > moveSense.x)
        {
            sprite.flipX = false;
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (move_stick.Horizontal < -moveSense.x)
        {
            sprite.flipX = true;
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }


        if (move_stick.Vertical > moveSense.y)
        {
            if (anim.GetBool("ground"))
            {
                anim.SetTrigger("jump");
                rb.velocity = Vector2.up * jumpForce;
            }
        }

    }

    void Attack()
    {
        if (shootStick.Horizontal > moveSense.x || shootStick.Horizontal < -moveSense.x || shootStick.Vertical > moveSense.y || shootStick.Vertical < -moveSense.y)
        {
            vomit.transform.position = mouth.transform.position;
            anim.SetBool("atk", true);
            Instantiate(vomit);
        }
        else
        {
            anim.SetBool("atk", false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
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
