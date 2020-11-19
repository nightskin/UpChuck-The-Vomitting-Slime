using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vomit : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sprite;
    public Vector2 dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        float alpha = Random.Range(0, 1);
        float green = Random.Range(0, 1);
        sprite.color = new Color(0, green, 0, alpha);
    }

    
    void Update()
    {
        rb.AddForce(dir);
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(transform.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(transform.gameObject);
    }

}
