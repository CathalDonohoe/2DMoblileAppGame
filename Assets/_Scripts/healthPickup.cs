using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour
{
    public int healthAmount = 30;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if in contact with player
        if (other.tag == "Player")
        {
            //if health is below 100
            if(Health.healthValue < 100)
            {
                Health.healthValue += healthAmount;
                Destroy(gameObject);
                if(Health.healthValue >100){
                    Health.healthValue = 100;
                }
            }
        }
    }
}
