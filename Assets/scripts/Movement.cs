using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public float jumpspeed = 100f;
    public float jumpforce=5f;
    public Transform player;
    public Rigidbody2D rb;
    public static int health = 2;
    public GameObject crosshair;
    public float crosshairDistance=1.0f;
    public float  Bullet_Speed=2.0f;
    private Vector2 targetenemy;
    Vector2 movement;
    public Animator animator;
    public GameObject bulletprefabs;
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health = 0;
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        targetenemy = new Vector2(crosshair.transform.position.x, crosshair.transform.position.y);
        rb = GetComponent<Rigidbody2D>();
    }









    void Update()
    {
        movement.x= Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed",movement.sqrMagnitude);
        Aim();
        Shoot();
        
       
    }

   
       
    

    void FixedUpdate()
    {
        float moove = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        rb.velocity = new Vector2(jumpspeed * moove, rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jumped");
            rb.AddForce(new Vector2(rb.velocity.x, jumpforce));
        }
        if (health == 0)
        {
            Destroy(gameObject);
        }

    }

    void Aim()
    {
        if (movement != Vector2.zero)
        {
            crosshair.transform.localPosition = movement*crosshairDistance;
        }

    }


    void Shoot()
    {
        Vector2 shootingDirection = crosshair.transform.localPosition;
        shootingDirection.Normalize();
        
        if (Input.GetButtonDown("Fire1"))
        {
           
             GameObject bullet = Instantiate(bulletprefabs, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shootingDirection * Bullet_Speed;
            
            bulletprefabs.transform.position = Vector2.MoveTowards(transform.position,shootingDirection,Bullet_Speed*Time.deltaTime);
            Debug.Log("kkhasiseeeeeeeeee");
            Destroy(bulletprefabs, 2.0f);
        }
        
    }
}

