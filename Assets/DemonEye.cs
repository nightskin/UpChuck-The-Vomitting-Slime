using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonEye : MonoBehaviour
{
    public Collider2D target;
    public enum Direction
    {
        down,
        left,
        up,
        right
    }
    public Direction curent_dir;
    List<Direction> directions = new List<Direction>();
    public float LOS;
    public float peripheral;

    float offset2 = 0.67f; 
    float interval;
    float time;
    int index;
    bool looking;

    public float speed;

    public int hp;

    public List<Sprite> textures = new List<Sprite>();
    private SpriteRenderer renderer;
    private BoxCollider2D fov;
    Animator anim;
    public GameObject DeathAnim;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        directions.Add(Direction.down);
        directions.Add(Direction.left);
        directions.Add(Direction.up);
        directions.Add(Direction.right);
        time = 0;
        looking = true;
        interval = 1;
        index = (int)curent_dir;
        fov = transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = textures[index];
        anim = GetComponent<Animator>();
        
    }

    void ChangeDirection()
    {
        if(curent_dir == Direction.down)
        {
            curent_dir = Direction.left;
            renderer.sprite = textures[1];
            fov.offset = new Vector2(-LOS/2 + offset2, 0);
            fov.size = new Vector2(LOS, peripheral);
        }
        else if (curent_dir == Direction.left)
        {
            curent_dir = Direction.up;
            renderer.sprite = textures[2];
            fov.offset = new Vector2(0, LOS/2 + offset2);
            fov.size = new Vector2(peripheral, LOS);
        }
        else if (curent_dir == Direction.up)
        {
            curent_dir = Direction.right;
            renderer.sprite = textures[3];
            fov.offset = new Vector2(LOS/2 + offset2, 0);
            fov.size = new Vector2(LOS, peripheral);
        }
        else if (curent_dir == Direction.right)
        {
            curent_dir = Direction.down;
            renderer.sprite = textures[0];
            fov.offset = new Vector2(0, -LOS/2 + offset2);
            fov.size = new Vector2(peripheral, LOS);
        }
    }
    
    void Search()
    {
        if(time < interval)
        {
            time += Time.deltaTime;
        }
        else
        {
            ChangeDirection();
            time = 0;
        }
    }

    IEnumerator Halt(float delay)
    {
        yield return new WaitForSeconds(delay);
        looking = true;
    }

    void Attack()
    {
        int atkIndex = (int)curent_dir + 4;
        renderer.sprite = textures[atkIndex];

        if (curent_dir == Direction.down)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        else if (curent_dir == Direction.left)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (curent_dir == Direction.right)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if (curent_dir == Direction.up)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }


    }

    void Update()
    {
        if(hp < 1)
        {
            Instantiate(DeathAnim);
            DeathAnim.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }

        if (fov.IsTouching(target))
        {
            looking = false;
        }
        else
        {
            StartCoroutine(Halt(1.5f));
        }
        if (looking)
        {
            Search();
        }
        else
        {
            Attack();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Platforms" || other.gameObject.tag == "Hazard" || other.gameObject.tag == "Walls")
        {
            looking = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            hp -= 3;
        }
    }
}
