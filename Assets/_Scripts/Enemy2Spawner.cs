using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Spawner : MonoBehaviour
{
    //declaration of variables
    public GameObject enemy;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;

    // Update is called once per frame
    void Update()
    {
        //for spawning enemy
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range (22.6f, -22.6f);
            whereToSpawn = new Vector2(transform.position.x, randX);
            Instantiate (enemy, whereToSpawn, Quaternion.identity);

        }
    }
}
