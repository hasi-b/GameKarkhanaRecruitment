using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public Transform[] moveSpots;
    private int randomSpot;

    public Transform player;
    private float timeBtwnShots;
    public float startTimeBtwnShots;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwnShots = startTimeBtwnShots;
        randomSpot = Random.Range(0, moveSpots.Length);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = -speed;
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            randomSpot = Random.Range(0, moveSpots.Length);
        }
       

        if (timeBtwnShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwnShots = startTimeBtwnShots;
        }
        else
        {
            timeBtwnShots -= Time.deltaTime;
        }

    }
}
