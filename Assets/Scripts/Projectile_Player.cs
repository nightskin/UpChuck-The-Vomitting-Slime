using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile_Player : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector3 direction;
    public float startSize;
    public float maxSize;
    public float increment;
    public GameObject hud;
    Camera cam;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(direction.x, direction.y));
        transform.localScale = new Vector3(startSize, startSize, 1);
        float alpha = Random.value;
        GetComponent<SpriteRenderer>().color = new Color(0, 0.5f, 0, alpha);
        cam = Camera.current;
        hud = GameObject.Find("HUD");
    }
    
    void Update()
    {
        if(transform.localScale.x < maxSize && transform.localScale.y < maxSize)
        {
            transform.localScale += new Vector3(increment, increment, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Bullet")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Bullet")
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (hud != null)
        {
            hud.GetComponent<PlayerManager>().IncreaseAmmo(1);
        }
    }

}
