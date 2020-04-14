using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Follow : MonoBehaviour
{


    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    private Rigidbody2D rb;
    public Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots;
    
    public GameObject projecttile;
    [SerializeField] private AudioClip playerDeathsound;

    [SerializeField] private AudioClip EnemyDeathSound;

    [SerializeField] [Range(0f, 1.0f)] private float deathVolume = 0.5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }
    private void Update()
    {
        RotateTowards(player.position);

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        } else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;

        } else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        


        if(timeBtwShots <= 0){
            Instantiate(projecttile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        } else{
            timeBtwShots -= Time.deltaTime;
        }

    }
    
    
    private void MoveTowards(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void RotateTowards(Vector2 target)
    {
        var offset = 0f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;       
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    

    private void OnTriggerEnter2D(Collider2D whatHitMe)
    {
        //param is collider comp of whatever hit me -
        //different behaviour required
        //could check the tag type for the object
        //could check for different components
        var player = whatHitMe.GetComponent<PlayerMovement>();
        var bullet = whatHitMe.GetComponent<Bullet>();

        if (bullet)//if player != null
        {
            
            //plays when enemy is shot
            AudioSource.PlayClipAtPoint(EnemyDeathSound, Camera.main.transform.position, deathVolume);
           // GameObject explosion = Instantiate(explosionFX,
            //                                  transform.position,
            //                                  transform.rotation);
           // Destroy(explosion, explosionDuration);
           //Destroys bullet
            Destroy(bullet.gameObject);
           // PublishEnemyKilledEvent();
           //Destroys enemy
            Destroy(gameObject);
            Score.scoreValue += 20;

            
        }


    }
}
