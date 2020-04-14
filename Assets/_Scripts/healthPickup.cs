using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour
{
    public int healthAmount = 30;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
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
