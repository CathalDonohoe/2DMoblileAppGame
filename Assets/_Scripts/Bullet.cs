using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    const int DMG = 1;
    public float bulletSpeed = 80f;
    public Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyDamage enemy = collision.GetComponent<EnemyDamage>();

        if (enemy != null)
        {
            enemy.TakeDamage(DMG);
        }
        Destroy(gameObject);
    }
}
