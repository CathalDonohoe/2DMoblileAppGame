using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Follow : MonoBehaviour
{


    //declaration of variables
    public float speed;
    private Rigidbody2D rb;
    private Transform target;
    private int count = 0;

    [SerializeField] private AudioClip playerDeathsound;

    [SerializeField] private AudioClip EnemyDeathSound;

    [SerializeField] [Range(0f, 1.0f)] private float deathVolume = 0.5f;


    bool waitActive = false; //so wait function wouldn't be called many times per frame
 
    IEnumerator Wait()
    {
        waitActive = true;
        yield return new WaitForSeconds (3.0f);
        waitActive = false;
    }

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
    
    //transform  position to the players position
    private void MoveTowards(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    //rotate sprite to face player

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
        //different behaviour required could check for different components
        var player = whatHitMe.GetComponent<PlayerMovement>();
        var bullet = whatHitMe.GetComponent<Bullet>();

        if (player)//if player != null
        {
            //inflict damage on player?
            if (!waitActive)
            {
                Health.healthValue -= 20;
                StartCoroutine(Wait()); 
            }

            //destroy enemy
            //play when player is killed
            if (Health.healthValue <= 0)
            {
                AudioSource.PlayClipAtPoint(playerDeathsound, Camera.main.transform.position, deathVolume);
                Destroy(player.gameObject);
                Destroy(gameObject);
                Health.healthValue = 100;
                Score.scoreValue = 0;
                Application.LoadLevel(Application.loadedLevel);
            }
        }

        if (bullet)//if player != null
        {
            count++;
            AudioSource.PlayClipAtPoint(EnemyDeathSound, Camera.main.transform.position, deathVolume);
            if (count>=4){
                //plays when enemy is shot
                AudioSource.PlayClipAtPoint(EnemyDeathSound, Camera.main.transform.position, deathVolume);
           
                //Destroys bullet
                Destroy(bullet.gameObject);
           
                //Destroys enemy
                Destroy(gameObject);
                //adds 50 to score
                Score.scoreValue += 50;
            }
            
            

            
        }


    }
}
