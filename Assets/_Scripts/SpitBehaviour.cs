using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitBehaviour : MonoBehaviour
{
    //declaration of variables
    public float speed;
    private Transform player;
    private Vector2 target;


    [SerializeField] [Range(0f, 1.0f)] private float deathVolume = 0.5f;
    [SerializeField] private AudioClip playerDeathsound;



    void Start() {
        //setting player as a target
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
        
    }

    void Update(){
        //moves towards targets position
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y){
            //destroys once reaches area
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D whatHitMe)
    {
        var players = whatHitMe.GetComponent<PlayerMovement>();
        
        //if spit hits gameobject with palayercomponent
        if(players){
            //loose health
            Health.healthValue -= 10;
            //destroys spit
            DestroyProjectile();
            
            //if player dies
            if (Health.healthValue <= 0)
            {
                AudioSource.PlayClipAtPoint(playerDeathsound, Camera.main.transform.position, deathVolume);
                Destroy(players.gameObject);
                Destroy(gameObject);
                Health.healthValue = 100;
                Score.scoreValue = 0;
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        
    }

    void DestroyProjectile(){
        Destroy(gameObject);
    }
}
