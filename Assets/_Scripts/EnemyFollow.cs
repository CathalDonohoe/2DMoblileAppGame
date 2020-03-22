using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{


    public float speed;
    private Rigidbody2D rb;
    private Transform target;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }

   /* void OnCollisonEnter2D (Collision2D col)
    {
        if (col.gameObject.tag.Equals("Bullet"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D whatHitMe)
    {
        //param is collider comp of whatever hit me -
        //different behaviour required
        //could check the tag type for the object
        //could check for different components
        Debug.Log("Entered");
        var player = whatHitMe.GetComponent<PlayerMovement>();
        Debug.Log("Player"+player);
        var bullet = whatHitMe.GetComponent<Bullet>();
        Debug.Log("bullet"+bullet);

        if (player)//if player != null
        {
            //inflict damage on player?

            //destroy enemy
            //play sound clip when dead
            //AudioSource.PlayClipAtPoint(playerDeathClip, Camera.main.transform.position, deathVolume);
            Debug.Log("entered player");
            Destroy(player.gameObject);
            Destroy(gameObject);
        }

        if (bullet)//if player != null
        {
            //destroy enemyship & bullet
            //play sound clip when dead
            //AudioSource.PlayClipAtPoint(deathClip, Camera.main.transform.position, deathVolume);
           // GameObject explosion = Instantiate(explosionFX,
            //                                  transform.position,
            //                                  transform.rotation);
           // Destroy(explosion, explosionDuration);
            Destroy(bullet.gameObject);
            Debug.Log("entered Bullet");
           // PublishEnemyKilledEvent();
            Destroy(gameObject);
        }


    }
}
