using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
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
    public float shootForce;

    [Header("misc")]
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator anim;
    public GameObject hud;
    public Transform spawnPoint;
    public GameObject mouth;
    public GameObject DeathAnim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        hud = GameObject.Find("HUD");
        mouth = transform.GetChild(0).gameObject;
    }

    void Move()
    {
        anim.SetInteger("spdX",(int)rb.velocity.x);
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


        if(move_stick.Vertical > moveSense.y)
        {
            if (anim.GetBool("ground"))
            {
                anim.SetTrigger("jump");
                rb.velocity = Vector2.up * jumpForce;
            }
        }

    }
    
    void Update()
    {
        Move();
        Attack();
        if (hud.GetComponent<PlayerManager>().GetHP() < 1)
        {
            Die();
        }
    }

    void Attack()
    {
        if(shootStick.Horizontal > moveSense.x || shootStick.Horizontal < -moveSense.x || shootStick.Vertical > moveSense.y || shootStick.Vertical < -moveSense.y)
        {
            if (hud.GetComponent<PlayerManager>().GetAmmo() > 0)
            {
                vomit.transform.position = mouth.transform.position;
                vomit.GetComponent<Projectile_Player>().direction = new Vector3(shootStick.Horizontal * shootForce, shootStick.Vertical * shootForce);
                anim.SetBool("atk", true);
                Instantiate(vomit);
                hud.GetComponent<PlayerManager>().DecreaseAmmo(1);
            }
        }
        else
        {
            anim.SetBool("atk", false);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Hazard")
        {
            hud.GetComponent<PlayerManager>().DecreaseHP(10);
            transform.position = spawnPoint.position;
        }
        if(other.gameObject.tag == "Enemy")
        {
            hud.GetComponent<PlayerManager>().DecreaseHP(20);
        }
    }

    public void Die()
    {
        hud.GetComponent<PlayerManager>().SaveTime();
        Instantiate(DeathAnim);
        DeathAnim.transform.position = gameObject.transform.position;
        gameObject.SetActive(false);
    }

}
