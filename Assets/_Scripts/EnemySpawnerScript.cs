using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
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
        //timer for spawning enemies
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range (-47.4f, 47.4f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate (enemy, whereToSpawn, Quaternion.identity);

        }
    }
}
