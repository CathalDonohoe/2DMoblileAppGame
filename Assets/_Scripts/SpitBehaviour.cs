using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitBehaviour : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;


    [SerializeField] [Range(0f, 1.0f)] private float deathVolume = 0.5f;
    [SerializeField] private AudioClip playerDeathsound;
    void Start() {

        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
        
    }

    void Update(){
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y){
            DestroyProjectile();
            Debug.Log("Enter area");
        }
    }

    private void OnTriggerEnter2D(Collider2D whatHitMe)
    {
        Debug.Log("Enter trigger");
        var players = whatHitMe.GetComponent<PlayerMovement>();
        
        if(players){
            Debug.Log("Enter player");
            Health.healthValue -= 10;
            Debug.Log("mius");
            DestroyProjectile();
            

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
