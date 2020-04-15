using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    //declaration of variables
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletforce = 60f;


    [SerializeField] private AudioClip GunshotSound;

    [SerializeField] [Range(0f, 1.0f)] private float volume = 0.5f;

    // Update is called once per frame
    void Update()
    {

        //if player presses mouse1
        if (Input.GetButtonDown("Fire1"))
        {
            AudioSource.PlayClipAtPoint(GunshotSound, Camera.main.transform.position, volume);
            Shoot();
        }
        
    }


    void Shoot()
    {
        //calls prefab bullet and fires in direction firepoint if facing
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletforce, ForceMode2D.Impulse);
    }
}
