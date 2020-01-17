using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidor : MonoBehaviour
{
    public GameObject enemy;
    public static int score =0;
    // Start is called before the first frame update
    void Start()
    {
    }
   
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            score++;
            
        }
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
