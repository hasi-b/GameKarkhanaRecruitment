﻿using System.Collections;
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
        Instantiate(Enemy, SmoveSpots[SrandomSpot].position, Quaternion.identity);
        SrandomSpot = Random.Range(0, SmoveSpots.Length);
        
    }

    // Update is called once per frame
    void Update()
    {
       int dif= Mathf.Abs(collidor.score - count);
        if (timeBetwnSpawn <= 0 && dif<5)
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
