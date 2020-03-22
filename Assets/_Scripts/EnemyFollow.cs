using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{


    public float speed;
    private Rigidbody2D rb;
    private Transform target;
    

    [SerializeField] private AudioClip playerDeathsound;

    [SerializeField] private AudioClip EnemyDeathSound;

    [SerializeField] [Range(0f, 1.0f)] private float deathVolume = 0.5f;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > 1f)
        {
            MoveTowards(target.position);
            RotateTowards(target.position);
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

        if (player)//if player != null
        {
            //inflict damage on player?

            //destroy enemy
            //play when player is killed
            AudioSource.PlayClipAtPoint(playerDeathsound, Camera.main.transform.position, deathVolume);
            Destroy(player.gameObject);
            Destroy(gameObject);
        }

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
        }


    }
}
