using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] SmoveSpots;
    private int SrandomSpot;
    public GameObject Enemy;
    private float timeBetwnSpawn = 7;
    public float startTimeBtwnSpawn;
    private int count=0;

    // Start is called before the first frame update
    void Start()
    {
        SrandomSpot = Random.Range(0, SmoveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetwnSpawn <= 0 && count<5)
        {
            Instantiate(Enemy, SmoveSpots[SrandomSpot].position, Quaternion.identity);
            timeBetwnSpawn = startTimeBtwnSpawn;
            count++;
        }
        else
        {
            timeBetwnSpawn -= Time.deltaTime;
        }
    }
}
